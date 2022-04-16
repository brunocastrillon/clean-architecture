using Bookstore.Core.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> Get();

        Task<CategoryDTO> GetById(int id);

        Task Add(CategoryDTO categoryDTO);

        Task Update(CategoryDTO categoryDTO);

        Task Remove(int id);
    }
}