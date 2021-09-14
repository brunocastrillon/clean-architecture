using Bookstore.Core.Entities;
using Xunit;

namespace Bookstore.Teste.Unit.Core.Entities
{
    public class AuthorConstructor
    {
        private string _testName = "Robert C. Martin";
        private Author _testAuthor = null;

        public Author CreateAuthor()
        {
            return new Author(_testName);
        }

        [Fact]
        public void InitializeName()
        {
            _testAuthor = CreateAuthor();
            Assert.Equal(_testName, _testAuthor.Name);
        }
    }
}