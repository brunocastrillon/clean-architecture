using Bookstore.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Domain.Contracts
{
    public interface IBookRepository : IBaseRepository
    {
        Task<IEnumerable<Book>> GetAsync();

        Task<Book> GetByIdAsync(int id);
    }
}