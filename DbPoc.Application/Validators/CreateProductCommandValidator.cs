using DbPoc.Application.Commands.Products;
using FluentValidation;

namespace DbPoc.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Unit).NotEmpty();
            RuleFor(x => x.Vat).NotEmpty();

        }
    }
}
