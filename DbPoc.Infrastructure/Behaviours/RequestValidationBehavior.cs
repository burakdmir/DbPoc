using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Infrastructure.Behaviours
{
    class RequestValidationBehavior<TRequest, TResponse> : BasicPipelineBehaviour<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
        where TResponse : class

    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public override Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);

            List<ValidationFailure> failures = validators
               .Select(v => v.Validate(context))
               .SelectMany(result => result.Errors)
               .Where(f => f != null)
               .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
