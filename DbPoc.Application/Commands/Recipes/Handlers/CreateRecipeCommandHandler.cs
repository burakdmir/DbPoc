using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Commands.Recipes.Handlers
{
    class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, int>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public CreateRecipeCommandHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<int> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Recipe
            {
                ComponentProductId = request.ComponentProductId,
                CompositeProductId = request.CompositeProductId,
                ComponentQuantity = request.ComponentQuantity,
            };

            dbPocDbContext.Recipes.Add(entity);

            await dbPocDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
