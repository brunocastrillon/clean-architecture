using Bookstore.Core.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Author
{
    public interface IAuthorService
    {
        Task<AuthorDTO> Add(AuthorDTO authorDTO);

        Task<IEnumerable<AuthorDTO>> Get();

        Task<AuthorDTO> GetById(int id);

        Task<AuthorDTO> Remove(int id);

        Task<AuthorDTO> Update(AuthorDTO authorDTO);
    }
}