using DbPoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbPoc.Persistence.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Picture).HasColumnType("image");

            //builder.Property(e => e.StartTime).ValueGeneratedOnAddOrUpdate();
            //builder.Property(e => e.EndTime).ValueGeneratedOnAddOrUpdate();

        }
    }
}
