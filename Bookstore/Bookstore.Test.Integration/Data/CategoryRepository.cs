using Bookstore.Core.Domain.Entities;
using Bookstore.Infra.Data.Context;
using System.Threading.Tasks;
using Xunit;

namespace Bookstore.Test.Integration.Data
{
    public class CategoryRepository : InMemoryContext
    {
        protected Infra.Data.Repository.CategoryRepository GetRepository()
        {
            var options = DbContextOptions();

            _applicationDbContext = new ApplicationDbContext(options);

            return new Infra.Data.Repository.CategoryRepository(_applicationDbContext);
        }

        [Fact(DisplayName = "Create new category in-memory should not throw exception")]
        public async Task CreateNewCategoryInMemory()
        {
            var description = "category-integration-test";
            var category = new Category(description);
            var repository = GetRepository();
            var newCategory = await repository.CreateAsync(category);

            Assert.Equal(description, newCategory.Description);
            Assert.True(newCategory?.Id > 0);
        }
    }
}