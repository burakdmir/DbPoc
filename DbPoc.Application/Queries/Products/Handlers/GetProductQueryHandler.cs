using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Queries.Products.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public GetProductQueryHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
           Product product = await dbPocDbContext.Products.FindAsync(request.Id);

            if (product == null)
            {
                throw new Exception();
            }
            return product;
        }
    }
}
