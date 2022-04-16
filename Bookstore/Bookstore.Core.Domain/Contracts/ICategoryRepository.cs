using Bookstore.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Domain.Contracts
{
    public interface ICategoryRepository : IBaseRepository
    {
        Task<IEnumerable<Category>> GetAsync();

        Task<Category> GetByIdAsync(int id);
    }
}