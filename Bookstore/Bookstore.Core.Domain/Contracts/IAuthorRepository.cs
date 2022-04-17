using Bookstore.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Domain.Contracts
{
    public interface IAuthorRepository : IBaseRepository
    {
        Task<IEnumerable<Author>> GetAsync();

        Task<Author> GetByIdAsync(int id);
    }
}