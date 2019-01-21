using DbPoc.Application.Infrastructure;
using DbPoc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbPoc.Application.Queries.Products
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>, IMyCacheReader
    {
        public Type CacheType => typeof(Product);
    }
}
