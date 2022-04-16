using System.Threading.Tasks;

namespace Bookstore.Core.Domain.Contracts
{
    public interface IBaseRepository
    {
        Task<T> CreateAsync<T>(T entity) where T : class;

        Task<T> DeleteAsync<T>(T entity) where T : class;

        Task<T> UpdateAsync<T>(T entity) where T : class;
    }
}