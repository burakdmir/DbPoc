using DbPoc.Domain.Enums;
using MediatR;

namespace DbPoc.Application.Commands.Products
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Name { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Vat { get; set; }
        public UnitEnum Unit { get; set; }
    }
}
