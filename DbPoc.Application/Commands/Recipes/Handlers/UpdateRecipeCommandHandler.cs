using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Commands.Recipes.Handlers
{
    class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public UpdateRecipeCommandHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<Unit> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            Recipe oldProduct = await dbPocDbContext.Recipes.FindAsync(request.Id);

            if (oldProduct == null)
            {
                throw new Exception();
            }

            oldProduct.ComponentProductId = request.ComponentProductId;
            oldProduct.CompositeProductId = request.CompositeProductId;
            oldProduct.ComponentQuantity = request.ComponentQuantity;

            await dbPocDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
