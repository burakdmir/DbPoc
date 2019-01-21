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

        public Stopwatch Timer { get; }

        public RequestPerformancePipelineBehaviour(ILogger<TRequest> logger)
        {
            this.logger = logger;
            this.Timer = new Stopwatch();
        }

        public  async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Timer.Start();
            TResponse response = await next();
            Timer.Stop();

            string  name = typeof(TRequest).Name;

            logger.LogInformation($"Request:{request}; Name: {name}; execution time: {Timer.ElapsedMilliseconds} ms ;");

            return response;
        }
    }
}
