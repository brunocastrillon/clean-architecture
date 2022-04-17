using AutoMapper;
using Bookstore.Core.Application.DTO;
using Bookstore.Core.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Book
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task Add(BookDTO bookDTO)
        {
            var book = _mapper.Map<Domain.Entities.Book>(bookDTO);
            await _bookRepository.CreateAsync(book);
        }

        public async Task<IEnumerable<BookDTO>> Get()
        {
            var books = await _bookRepository.GetAsync();
            var mapped = _mapper.Map<IEnumerable<BookDTO>>(books);
            return mapped;
        }

        public async Task<BookDTO> GetById(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            var mapped = _mapper.Map<BookDTO>(book);
            return mapped;
        }

        public async Task Remove(int id)
        {
            var book = _bookRepository.GetByIdAsync(id).Result;
            await _bookRepository.DeleteAsync(book);
        }

        public async Task Update(BookDTO bookDTO)
        {
            var book = _mapper.Map<Domain.Entities.Book>(bookDTO);
            await _bookRepository.UpdateAsync(book);
        }
    }
}