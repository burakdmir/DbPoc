using DbPoc.Domain.Enums;
using MediatR;

namespace DbPoc.Application.Commands.Products
{
    public class UpdateProductCommand:IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
            
        public decimal NetPrice { get; set; }

        public decimal Vat { get; set; }

        public decimal Quantity { get; set; }

        public UnitEnum Unit { get; set; }
    }
}
