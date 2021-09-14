using Bookstore.Core.Entities;
using Xunit;

namespace Bookstore.Teste.Unit.Core.Entities
{
    public class BookConstructor
    {
        private string _testTitle = "Clean Architecture";
        private Book _testBook = null;

        public Book CreateBook()
        {
            return new Book(_testTitle);
        }

        [Fact]
        public void InitializeTitle()
        {
            _testBook = CreateBook();
            Assert.Equal(_testTitle, _testBook.Title);
        }
    }
}