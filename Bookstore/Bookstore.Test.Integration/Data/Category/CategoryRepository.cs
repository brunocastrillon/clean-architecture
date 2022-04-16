using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Test.Integration.Data.Category
{
    public class CategoryRepository
    {
        protected ApplicationDbContext _applicationDbContext;

        protected static DbContextOptions<ApplicationDbContext> DbContextOptions()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseInMemoryDatabase("Bookstore").UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected Infra.Data.Repository.CategoryRepository GetRepository()
        {
            var options = DbContextOptions();

            _applicationDbContext = new ApplicationDbContext(options);

            return new Infra.Data.Repository.CategoryRepository(_applicationDbContext);
        }
    }
}