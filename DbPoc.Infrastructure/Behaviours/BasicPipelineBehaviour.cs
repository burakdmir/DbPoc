using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DbPoc.Infrastructure.Behaviours
{
    internal abstract class BasicPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class

    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
}