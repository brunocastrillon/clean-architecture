using Bookstore.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Domain.Contracts
{
    public interface IAuthorRepository
    {
        //Task<Author> CreateAsync(Author author);

        //Task<Author> DeleteAsync(Author author);

        Task<IEnumerable<Author>> GetAsync();

        Task<Author> GetByIdAsync(int id);

        //Task<Author> UpdateAsync(Author author);
    }
}