using DbPoc.Application.Infrastructure;
using DbPoc.Domain.Entities;
using MediatR;
using System;

namespace DbPoc.Application.Commands.Products
{
    public class DeleteProductCommand: IRequest, IMyCacheWriter
    {
        public int Id { get; set; }
        public Type CacheType => typeof(Product);

    }
}
