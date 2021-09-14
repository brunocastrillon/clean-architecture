using Bookstore.Core.Entities;
using Bookstore.Infra.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Bookstore.Teste.Integration.Data
{
    public class BaseEntityFrameworkRepository
    {
        protected DataBaseContext _dbContext;

        protected static DbContextOptions<DataBaseContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<DataBaseContext>();                                                   

            builder.UseInMemoryDatabase("mySupply").UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected EntityFrameworkRepository<Author> GetRepository()
        {
            var options = CreateNewContextOptions();
            var mockMediator = new Mock<IMediator>();

            _dbContext = new DataBaseContext(options, mockMediator.Object);
            return new EntityFrameworkRepository<Author>(_dbContext);
        }
    }
}