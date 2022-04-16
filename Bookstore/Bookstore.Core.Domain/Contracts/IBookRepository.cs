using Bookstore.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Domain.Contracts
{
    public interface IBookRepository
    {
        //Task<Book> CreateAsync(Book book);

        //Task<Book> DeleteAsync(Book book);

        Task<IEnumerable<Book>> GetAsync();

        Task<Book> GetByIdAsync(int id);

        //Task<Book> UpdateAsync(Book book);
    }
}