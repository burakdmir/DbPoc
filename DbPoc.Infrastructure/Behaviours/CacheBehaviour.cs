using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Infrastructure.Behaviours
{
    class CacheBehaviour<TRequest, TResponse> : BasicPipelineBehaviour<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
    {
        public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = await next();
            return response;
        }


    }
}
