using MediatR;

namespace DbPoc.Application.Commands.Products
{
    public class DeleteProductCommand: IRequest
    {
        public int Id { get; set; }
    }
}
