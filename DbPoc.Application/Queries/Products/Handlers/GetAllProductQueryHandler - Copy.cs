using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Queries.Products.Handlers
{
    class GetAllProductByTimeQueryHandler : IRequestHandler<GetAllProductByTimeQuery, IEnumerable<Product>>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public GetAllProductByTimeQueryHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductByTimeQuery request, CancellationToken cancellationToken)
        {
            return await dbPocDbContext
                .Products
                .AsNoTracking()
                .Where(p =>request.StartTime <=  p.StartTime)
                .ToListAsync();
        }
    }
}
