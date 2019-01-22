using DbPoc.Application.Infrastructure;
using DbPoc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace DbPoc.Application.Queries.Products
{
    public class GetAllProductWithRecipeByTimeQuery:IRequest<IEnumerable<Product>>, IMyCacheReader
    {
        public DateTime? StateTime { get; set; }
        public Type CacheType => typeof(Product);

    }
}
