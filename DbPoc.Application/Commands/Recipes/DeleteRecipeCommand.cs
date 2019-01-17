using MediatR;

namespace DbPoc.Application.Commands.Recipes
{
    public  class DeleteRecipeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
