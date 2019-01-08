using DbPoc.Domain.Enums;

namespace DbPoc.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal NetPrice { get; set; }

        public decimal Vat { get; set; }

        public byte[] Picture { get; set; }

        public decimal Quantity { get; set; }

        public UnitEnum   Unit { get; set; }
    }
}
    