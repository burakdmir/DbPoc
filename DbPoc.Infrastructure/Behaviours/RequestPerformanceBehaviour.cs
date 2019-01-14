using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DbPoc.Infrastructure.Behaviours
{
    class RequestPerformancePipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> logger;

        public Stopwatch timer { get; }

        public RequestPerformancePipelineBehaviour(ILogger<TRequest> logger)
        {
            this.logger = logger;
            this.timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            timer.Start();
            TResponse response = await next();
            timer.Stop();

            string  name = typeof(TRequest).Name;

            logger.LogInformation($"Request:{request}; Name: {name}; execution time: {timer.ElapsedMilliseconds} ms ;");

            return response;
        }
    }
}
