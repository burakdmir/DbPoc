using MediatR;

namespace DbPoc.Application.Commands.Recipes
{
    public class CreateRecipeCommand : IRequest<int>
    {
        public int CompositeProductId { get; set; }
        public int ComponentProductId { get; set; }
        public decimal ComponentQuantity { get; set; }
    }
}
