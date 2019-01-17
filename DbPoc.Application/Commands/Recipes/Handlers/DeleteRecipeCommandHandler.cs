using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Commands.Recipes.Handlers
{
    class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {

        private readonly DbPocDbContext dbPocDbContext;

        public DeleteRecipeCommandHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            Recipe recipe = await dbPocDbContext.Recipes.FindAsync(request.Id);

            dbPocDbContext.Remove(recipe);

            await dbPocDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
