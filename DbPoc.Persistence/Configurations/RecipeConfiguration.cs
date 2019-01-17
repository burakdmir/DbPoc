using DbPoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbPoc.Persistence.Configurations
{
    class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasOne(r => r.CompositeProduct)
                .WithMany(r => r.ComponentProducts);

            builder.HasOne(r => r.ComponentProduct)
                .WithMany(r => r.CompositeProducts);

            //builder.Property(e => e.StartTime).ValueGeneratedOnAddOrUpdate();
            //builder.Property(e => e.EndTime).ValueGeneratedOnAddOrUpdate();
        }
    }
}
