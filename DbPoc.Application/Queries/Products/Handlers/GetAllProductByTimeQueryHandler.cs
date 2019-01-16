using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
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
            //return await dbPocDbContext
            //    .Products
            //    .AsNoTracking()
            //    .Where(p =>   p.StartTime <= request.StartTime)
            //    .ToListAsync();

            return await dbPocDbContext
               .Products
               .AsNoTracking()
               .FromSql($"SELECT * FROM Products FOR SYSTEM_TIME '{request.StartTime}' AND '{DateTime.UtcNow}'")
               .ToListAsync();
        }
    }
}
