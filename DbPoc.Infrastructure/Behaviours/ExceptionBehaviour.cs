﻿using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Infrastructure.Behaviours
{
    class ExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>

    {
        private readonly ILogger<TRequest> logger;

        public ExceptionBehaviour(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }

        public  async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {

                TResponse response = await next();
                return response;
            }
            catch (Exception ex)
            {
                logger.LogCritical($"Exception: {ex}");
                throw;//todo

            }
        }
    }
}
