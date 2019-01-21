using Dapper;
using Dapper.Mapper;
using DbPoc.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Queries.Products.Handlers
{
    class GetAllProductWithRecipeByTimeQueryHandler : IRequestHandler<GetAllProductWithRecipeByTimeQuery, IEnumerable<Product>>
    {
        private readonly IConfigurationRoot configurationRoot;

        public GetAllProductWithRecipeByTimeQueryHandler(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductWithRecipeByTimeQuery request, CancellationToken cancellationToken)
        {
            string sqlFormattedDate = request.StateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = $@"SELECT * FROM Products FOR SYSTEM_TIME AS OF '{sqlFormattedDate}' p 
  join recipes FOR SYSTEM_TIME AS OF '{sqlFormattedDate}' r
  on p.id = r.compositeProductId ";

            using (var connection = new SqlConnection(configurationRoot.GetConnectionString("DbPocDatabase")))
            {
                var productDictionary = new Dictionary<int, Product>();


                IEnumerable<Product> list = await connection.QueryAsync<Product, Recipe, Product>(
                    sql,
                    (product, recipe) =>
                    {

                        if (!productDictionary.TryGetValue(product.Id, out Product productEntry))
                        {
                            productEntry = product;
                            productEntry.ComponentProducts = new List<Recipe>();
                            productDictionary.Add(productEntry.Id, productEntry);
                        }

                        productEntry.ComponentProducts.Add(recipe);
                        return productEntry;
                    },
                    splitOn: "Id");

               // IEnumerable<Product> list = await connection.QueryAsync<Product, Recipe>(sql);// dapper.mapper



                return list.ToList();


            }
        }
    }
}
