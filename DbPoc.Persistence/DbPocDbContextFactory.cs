using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace DbPoc.Persistence
{
    class DbPocDbContextFactory : IDesignTimeDbContextFactory<DbPocDbContext>
    {
        public DbPocDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("dbSettings.json")
               //.AddJsonFile($"appsettings.Local.json", optional: true)
               //.AddJsonFile($"appsettings.{environmentName}.json", optional: true)
               .Build();

            var connectionString = configuration.GetConnectionString("DbPocDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<DbPocDbContext>();

            optionsBuilder.UseSqlServer(connectionString);
            return new DbPocDbContext(optionsBuilder.Options);
        }
    }
}
