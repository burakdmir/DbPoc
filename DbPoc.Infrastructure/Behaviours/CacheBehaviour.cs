using DbPoc.Application.Infrastructure;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Infrastructure.Behaviours
{
    class CacheBehaviour<TRequest, TResponse> : BasicPipelineBehaviour<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
        where TResponse : class
    {
        private readonly IMemoryCache memoryCache;

        public CacheBehaviour(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            if (request is IMyCacheReader && request is IMyCacheWriter)
            {
                throw new InvalidOperationException();
            }
            Type cacheType = null;
            if (request is IMyCache myCache)
            {
                cacheType = myCache.CacheType;
            }

            string key = request.GetType().Name;
            if (cacheType != null)
            {
                var dic1 = memoryCache.Get<Dictionary<string, object>>(cacheType);
                if (dic1?.ContainsKey(key) ?? false)
                {
                    if (request is IMyCacheWriter cachewriter)
                    {
                        dic1.Remove(key);
                    }
                    else
                    {
                        return dic1[key] as TResponse;
                    }
                }
            }

            TResponse response = await next();

            if (request is IMyCacheReader cacheReader2)
            {
                var dic2 = memoryCache.Get<Dictionary<string, object>>(cacheType);
                if (dic2 == null)
                {
                    var cacheDic = new Dictionary<string, object>();
                    cacheDic[request.GetType().Name] = response;
                    memoryCache.Set(cacheType, cacheDic);
                }
                else
                {

                    dic2[request.GetType().Name] = response;
                    memoryCache.Set(cacheType, dic2);
                }

            }
            return response;

        }


    }
}
