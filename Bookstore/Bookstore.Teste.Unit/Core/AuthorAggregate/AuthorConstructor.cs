using Bookstore.Core.AuthorAggregate;
using Xunit;

namespace Bookstore.Teste.Unit.Core.AuthorAggregate
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

        [Fact]
        public void InitializeEmptyBookList()
        {
            _testAuthor = CreateAuthor();
            Assert.NotNull(_testAuthor.Books);
        }
    }
}