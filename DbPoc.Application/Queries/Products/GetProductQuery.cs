using DbPoc.Domain.Entities;
using MediatR;

namespace DbPoc.Application.Queries.Products
{
    public class GetProductQuery:IRequest<Product> 
    {
        public int Id { get; set; }
    }
}
