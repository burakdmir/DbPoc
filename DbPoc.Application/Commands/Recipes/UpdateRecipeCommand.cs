using MediatR;

namespace DbPoc.Application.Commands.Recipes
{
    public class UpdateRecipeCommand:IRequest
    {
        public int Id { get; set; }
        public int CompositeProductId { get; set; }
        public int ComponentProductId { get; set; }
        public decimal ComponentQuantity { get; set; }
    }
}   
