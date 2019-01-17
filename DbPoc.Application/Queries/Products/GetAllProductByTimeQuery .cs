using DbPoc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbPoc.Application.Queries.Products
{
    public class GetAllProductByTimeQuery : IRequest<IEnumerable<Product>>
    {
        public DateTime StateTime { get; set; }
    }
}
