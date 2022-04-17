using Bookstore.Core.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Book
{
    public interface IBookService
    {
        Task Add(BookDTO bookDTO);

        Task<IEnumerable<BookDTO>> Get();

        Task<BookDTO> GetById(int id);

        Task Remove(int id);

        Task Update(BookDTO bookDTO);
    }
}