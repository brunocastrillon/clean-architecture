using Bookstore.Core.Domain.Entities;
using Bookstore.Infra.Data.Context;
using System.Threading.Tasks;
using Xunit;

namespace Bookstore.Test.Integration.Data
{
    public class AuthorRepository : InMemoryContext
    {
        protected Infra.Data.Repository.AuthorRepository GetRepository()
        {
            var options = DbContextOptions();

            _applicationDbContext = new ApplicationDbContext(options);

            return new Infra.Data.Repository.AuthorRepository(_applicationDbContext);
        }

        [Fact(DisplayName = "Create new author in-memory should not throw exception")]
        public async Task CreateNewAuthorInMemory()
        {
            var name = "name";
            var bio = "bio";
            var author = new Author(name, bio);
            var repository = GetRepository();
            var newAuthor = await repository.CreateAsync(author);

            Assert.Equal(name, newAuthor.Name);
            Assert.Equal(bio, newAuthor.Bio);

            Assert.True(newAuthor?.Id > 0);
        }
    }
}