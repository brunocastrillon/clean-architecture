using Bookstore.Core.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Category
{
    public interface ICategoryService
    {
        Task Add(CategoryDTO categoryDTO);

        Task<IEnumerable<CategoryDTO>> Get();

        Task<CategoryDTO> GetById(int id);

        Task Remove(int id);

        Task Update(CategoryDTO categoryDTO);
    }
}