using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace DbPoc.Persistence
{
    class DbPocDbContextFactory : IDesignTimeDbContextFactory<DbPocDbContext>
    {

        public DbPocDbContext CreateDbContext(string[] args)
        {
            string connectionString = String.Empty;
            if (args == null || args.Length == 0)
            {
                string basePath = Directory.GetCurrentDirectory();
                var configuration = new ConfigurationBuilder()
                   .SetBasePath(basePath)
                   .AddJsonFile("dbSettings.json")
                   //.AddJsonFile($"appsettings.Local.json", optional: true)
                   //.AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                   .Build();
                connectionString = configuration.GetConnectionString("DbPocDatabase");
            }
            else
            {
                connectionString = args.First();
            }

            var optionsBuilder = new DbContextOptionsBuilder<DbPocDbContext>();

            optionsBuilder.UseSqlServer(connectionString);
            return new DbPocDbContext(optionsBuilder.Options);
        }
    }
}
