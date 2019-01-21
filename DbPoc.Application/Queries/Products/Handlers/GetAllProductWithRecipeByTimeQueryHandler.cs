using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Queries.Products.Handlers
{
    class GetAllProductWithRecipeByTimeQueryHandler : IRequestHandler<GetAllProductWithRecipeByTimeQuery, IEnumerable<Product>>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public GetAllProductWithRecipeByTimeQueryHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductWithRecipeByTimeQuery request, CancellationToken cancellationToken)
        {

            string sqlFormattedDate = request.StateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return await dbPocDbContext
               .Products
               .AsNoTracking()
               .FromSql($@"SELECT p.Id, p.NetPrice,p.Vat,p.ParentId,p.Name,p.Unit,CompositeProducts.*  FROM Products FOR SYSTEM_TIME AS OF {sqlFormattedDate} p
JOIN recipes  FOR SYSTEM_TIME AS OF {sqlFormattedDate} CompositeProducts
on p.id = CompositeProducts.compositeProductId ")
               .ToListAsync();
        }
    }
}
