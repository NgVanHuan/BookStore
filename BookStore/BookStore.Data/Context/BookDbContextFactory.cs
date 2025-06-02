using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStore.Data.Context
{
    public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
    {
        public BookDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BookStore.Web"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BookDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BookConnection"));

            return new BookDbContext(optionsBuilder.Options);
        }
    }
}
