using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Infrastructure.Behaviours
{
    class ExceptionBehaviour<TRequest, TResponse> : BasicPipelineBehaviour<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
        where TResponse : class

    {
        private readonly ILogger<TRequest> logger;

        public ExceptionBehaviour(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }

        public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
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
