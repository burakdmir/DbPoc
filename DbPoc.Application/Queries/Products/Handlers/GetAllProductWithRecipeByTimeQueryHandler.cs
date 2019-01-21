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
            //await dbPocDbContext
            //    .Recipes
            //    .AsNoTracking()
            //    .FromSql($" SELECT * FROM Recipes FOR SYSTEM_TIME AS OF {sqlFormattedDate}")
            //    .LoadAsync();

            IEnumerable<Product> result = await dbPocDbContext
               .Products
              .FromSql($"SELECT * FROM dbo.GetProductsRecipe({sqlFormattedDate})")       
               .ToListAsync();

            var pr =  dbPocDbContext.Recipes.Local.ToList();
          

            return result;
        }
    }
}
