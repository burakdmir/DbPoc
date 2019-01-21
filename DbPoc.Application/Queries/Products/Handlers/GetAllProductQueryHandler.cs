using Dapper;
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
    class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IConfigurationRoot configurationRoot;

        public GetAllProductQueryHandler(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            //return await dbPocDbContext
            //    .Products
            //    .AsNoTracking()
            //    .ToListAsync();
            string sql = $"SELECT * FROM Products ";

            using (var connection = new SqlConnection(configurationRoot.GetConnectionString("DbPocDatabase")))
            {
                IEnumerable<Product> result = await connection.QueryAsync<Product>(sql);

                return result.ToList();
            }
        }
    }
}
