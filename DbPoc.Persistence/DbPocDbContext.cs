using DbPoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbPoc.Persistence
{
    class DbPocDbContext: DbContext
    {

        DbSet<Product> Products { get; set; }

        public DbPocDbContext(DbContextOptions<DbPocDbContext> options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbPocDbContext).Assembly);
        }
    }
}
