using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Commands.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public CreateProductCommandHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Name = request.Name,
                NetPrice = request.NetPrice,
                Quantity = request.Quantity,
                Unit = request.Unit,
                Vat = request.Vat
            };

            dbPocDbContext.Products.Add(entity);

            await dbPocDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
