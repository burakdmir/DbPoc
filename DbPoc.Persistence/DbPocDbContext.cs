using System;
using DbPoc.Domain.Entities;
using DbPoc.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DbPoc.Persistence
{
   public  class DbPocDbContext : DbContext
    {

       public DbSet<Product> Products { get; set; }
       public DbSet<Recipe> Recipes { get; set; }

        public DbPocDbContext(DbContextOptions<DbPocDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbPocDbContext).Assembly);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {

            Product(modelBuilder);
        }

        private void Product(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Product>()
                 .HasData(new Product { Id = 1, Name = "Tej", NetPrice = 230, Vat = 5, Unit = UnitEnum.Liter },
                 new Product { Id = 2, Name = "Kenyér", NetPrice = 230, Vat = 5, Unit = UnitEnum.Kg },
                 new Product { Id = 3, Name = "Herz szalámi", NetPrice = 230, Vat = 5,  Unit = UnitEnum.Piece });
        }
    }
}
