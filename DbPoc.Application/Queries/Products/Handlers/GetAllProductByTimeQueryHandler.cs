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
         
            string sqlFormattedDate = request.StateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return await dbPocDbContext
               .Products
               .AsNoTracking()
               .FromSql($"SELECT * FROM Products FOR SYSTEM_TIME AS OF {sqlFormattedDate}")
               .ToListAsync();
        }
    }
}
