namespace DbPoc.Domain.Entities
{
    public class Recipe : BasicEntity
    {
        public int? CompositeProductId { get; set; }
        public virtual Product CompositeProduct { get; set; }
        public int? ComponentProductId { get; set; }
        public virtual Product ComponentProduct { get; set; }
        public decimal ComponentQuantity { get; set; }
    }
}
