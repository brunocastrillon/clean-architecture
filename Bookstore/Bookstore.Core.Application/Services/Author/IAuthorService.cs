using Bookstore.Core.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Author
{
    public interface IAuthorService
    {
        Task Add(AuthorDTO authorDTO);

        Task<IEnumerable<AuthorDTO>> Get();

        Task<AuthorDTO> GetById(int id);
        Task Remove(int id);

        Task Update(AuthorDTO authorDTO);
    }
}