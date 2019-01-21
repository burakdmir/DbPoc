using DbPoc.Application.Infrastructure;
using DbPoc.Domain.Entities;
using MediatR;
using System;

namespace DbPoc.Application.Queries.Products
{
    public class GetProductQuery:IRequest<Product>, IMyCacheReader
    {
        public int Id { get; set; }
        public Type CacheType => typeof(Product);

    }
}
