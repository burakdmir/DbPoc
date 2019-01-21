using Dapper;
using DbPoc.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Queries.Products.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IConfigurationRoot configurationRoot;

        public GetProductQueryHandler(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            //Product product = await dbPocDbContext.Products.FindAsync(request.Id);

            //if (product == null)
            //{
            //    throw new Exception();
            //}
            //return product;

            //using (var connection = new SqlConnection(configurationRoot.GetConnectionString("DbPocDatabase")))
            //{
            //    return await connection.GetAsync<Product>(request.Id);
            //}


            string sql = $"SELECT * FROM Products WHERE Id = {request.Id}";

            using (var connection = new SqlConnection(configurationRoot.GetConnectionString("DbPocDatabase")))
            {
                return await connection.QueryFirstAsync<Product>(sql);

            }
        }
    }
}
