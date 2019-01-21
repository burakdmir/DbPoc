using DbPoc.Application.Infrastructure;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Infrastructure.Behaviours
{
    class CacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IMemoryCache memoryCache;

        public CacheBehaviour(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
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
                var preCache = memoryCache.Get<Dictionary<string, string>>(cacheType);
                if (preCache?.ContainsKey(key) ?? false && request is IMyCacheReader)
                {
                    return JsonConvert.DeserializeObject<TResponse>(preCache[key]);
                }
                if (preCache != null && request is IMyCacheWriter )
                {
                    preCache.Clear();
                    memoryCache.Set(cacheType, preCache);
                }
            }

            TResponse response = await next();

            if (request is IMyCacheReader cacheReader2)
            {
                var postCache = memoryCache.Get<Dictionary<string, string>>(cacheType);
                if (postCache == null)
                {
                    var initCache = new Dictionary<string, string>();
                    initCache[key] = JsonConvert.SerializeObject(response);
                    memoryCache.Set(cacheType, initCache);
                }
                else
                {

                    postCache[key] = JsonConvert.SerializeObject(response);
                    memoryCache.Set(cacheType, postCache);
                }

            }
            return response;

        }


    }
}
