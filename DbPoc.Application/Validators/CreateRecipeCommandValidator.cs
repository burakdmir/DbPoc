using DbPoc.Application.Commands.Recipes;
using FluentValidation;

namespace DbPoc.Application.Validators
{
    class CreateRecipeCommandValidator:AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            RuleFor(r => r.ComponentProductId).NotEmpty();
            RuleFor(r => r.CompositeProductId).NotEmpty();
            RuleFor(r => r.ComponentQuantity).NotEmpty();
        }
    }
}
