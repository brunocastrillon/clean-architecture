using Bookstore.Core.Domain.Entities;
using Bookstore.Infra.Data.Context;
using System.Threading.Tasks;
using Xunit;

namespace Bookstore.Test.Integration.Data
{
    public class BookRepository : InMemoryContext
    {
        protected Infra.Data.Repository.BookRepository GetRepository()
        {
            var options = DbContextOptions();

            _applicationDbContext = new ApplicationDbContext(options);

            return new Infra.Data.Repository.BookRepository(_applicationDbContext);
        }

        [Fact(DisplayName = "Create new book in-memory should not throw exception")]
        public async Task CreateNewBookInMemory()
        {
            var title = "title";
            var description = "description";
            var publicationYear = "publicationYear";
            var book = new Book(title, description, publicationYear);
            var repository = GetRepository();
            var newBook = await repository.CreateAsync(book);

            Assert.Equal(title, newBook.Title);
            Assert.Equal(description, newBook.Description);
            Assert.Equal(publicationYear, newBook.PublicationYear);
            
            Assert.True(newBook?.Id > 0);
        }
    }
}