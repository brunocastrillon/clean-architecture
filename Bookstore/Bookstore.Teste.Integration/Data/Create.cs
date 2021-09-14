using Bookstore.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Bookstore.Teste.Integration.Data
{
    public class Create : BaseEntityFrameworkRepository
    {
        [Fact]
        public async Task CreateAuthorAndSetId()
        {
            var _testName = "J.R.R Tolkien";
            var _repository = GetRepository();
            var _author = new Author(_testName);

            await _repository.Create(_author);

            var newAuthor = (await _repository.List()).FirstOrDefault();

            Assert.Equal(_testName, newAuthor.Name);
            Assert.True(newAuthor?.Id > 0);
        }
    }
}