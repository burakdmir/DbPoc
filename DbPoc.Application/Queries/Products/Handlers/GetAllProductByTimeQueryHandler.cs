using Dapper;
using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Queries.Products.Handlers
{
    class GetAllProductByTimeQueryHandler : IRequestHandler<GetAllProductByTimeQuery, IEnumerable<Product>>
    {
        private readonly IConfigurationRoot configurationRoot;

        public GetAllProductByTimeQueryHandler(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductByTimeQuery request, CancellationToken cancellationToken)
        {

            string sqlFormattedDate = request.StateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            //return await dbPocDbContext
            //   .Products
            //   .AsNoTracking()
            //   .FromSql($"SELECT * FROM Products FOR SYSTEM_TIME AS OF {sqlFormattedDate}")
            //   .ToListAsync();
            string sql = $"SELECT * FROM Products FOR SYSTEM_TIME AS OF '{sqlFormattedDate}'";

            using (var connection = new SqlConnection(configurationRoot.GetConnectionString("DbPocDatabase")))
            {
                IEnumerable<Product> result = await connection.QueryAsync<Product>(sql);

                return result.ToList();
            }
        }
    }
}
