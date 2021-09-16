using Bookstore.Core.AuthorAggregate;
using Bookstore.Core.Entities;
using System;
using Xunit;

namespace Bookstore.Teste.Unit.Core.AuthorAggregate
{
    public class AuthorAddBook
    {
        private Author _authorTest = new Author("Martin Fowler");

        [Fact]
        public void AddBook()
        {
            Book bookTest = new Book("Domain-Driven Design", "Alguma descrição");
            _authorTest.AddBook(bookTest);

            Assert.Contains(bookTest, _authorTest.Books);
        }

        //[Fact]
        //public void ThrowExceptionWithNullBook()
        //{
        //    Action action = () => _authorTest.AddBook(null);
        //    var ex = Assert.Throws<ArgumentNullException>(action);
        //    Assert.Equal("newBook", ex.ParamName);
        //}
    }
}