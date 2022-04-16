using System.Threading.Tasks;
using Xunit;

namespace Bookstore.Test.Integration.Data.Category
{
    public class CreateCategory : CategoryRepository
    {
        [Fact(DisplayName = "Create new category in-memory")]
        public async Task CreateCategoryAndSetId()
        {
            var _description = "category-integration-test";
            var _category = new Core.Domain.Entities.Category(_description);
            var _repository = GetRepository();

            var newCategory = await _repository.CreateAsync(_category);

            Assert.Equal(_description, newCategory.Description);
            Assert.True(newCategory?.Id > 0);
        }
    }
}