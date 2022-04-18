using Bookstore.Core.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Book
{
    public interface IBookService
    {
        Task<BookDTO> Add(BookDTO bookDTO);

        Task<IEnumerable<BookDTO>> Get();

        Task<BookDTO> GetById(int id);

        Task<BookDTO> Remove(int id);

        Task<BookDTO> Update(BookDTO bookDTO);
    }
}