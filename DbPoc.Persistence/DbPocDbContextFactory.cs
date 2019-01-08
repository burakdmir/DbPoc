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
            //string basePath = Directory.GetCurrentDirectory();
            //var configuration = new ConfigurationBuilder()
            //   .SetBasePath(basePath)
            //   .AddJsonFile("dbSettings.json")
            //   //.AddJsonFile($"appsettings.Local.json", optional: true)
            //   //.AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            //   .Build();
            if(args == null || args.Length == 0)
            {
                throw new ArgumentNullException();
            }
            var connectionString = args.First();// configuration.GetConnectionString("DbPocDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<DbPocDbContext>();

            optionsBuilder.UseSqlServer(connectionString);
            return new DbPocDbContext(optionsBuilder.Options);
        }
    }
}
