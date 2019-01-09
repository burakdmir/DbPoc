using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Commands.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public UpdateProductCommandHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product oldProduct = await dbPocDbContext.Products.FindAsync(request.Id);

            if (oldProduct == null)
            {
                throw new Exception();
            }

            oldProduct.Name = request.Name;
            oldProduct.NetPrice = request.NetPrice ;
            oldProduct.Quantity = request.Quantity;
            oldProduct.Unit = request.Unit;
            oldProduct.Vat = request.Vat;

            await dbPocDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
