using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.SharedKernel.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        Task<List<TEntity>> List();
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Read(int id);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
    }
}