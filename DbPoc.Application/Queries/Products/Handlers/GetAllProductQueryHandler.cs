using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Queries.Products.Handlers
{
    class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public GetAllProductQueryHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await dbPocDbContext
                .Products
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
