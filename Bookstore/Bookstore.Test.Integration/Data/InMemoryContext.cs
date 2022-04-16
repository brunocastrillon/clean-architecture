using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Test.Integration.Data
{
    public class InMemoryContext
    {
        protected ApplicationDbContext _applicationDbContext;

        protected static DbContextOptions<ApplicationDbContext> DbContextOptions()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseInMemoryDatabase("Bookstore").UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}