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

        public async Task<BookDTO> Add(BookDTO dto)
        {
            var entity = _mapper.Map<Domain.Entities.Book>(dto);
            var entityResult = await _bookRepository.CreateAsync(entity);
            var dtoResult = _mapper.Map<BookDTO>(entityResult);
            return dtoResult;
        }

        public async Task<IEnumerable<BookDTO>> Get()
        {
            var entity = await _bookRepository.GetAsync();
            var dto = _mapper.Map<IEnumerable<BookDTO>>(entity);
            return dto;
        }

        public async Task<BookDTO> GetById(int id)
        {
            var entity = await _bookRepository.GetByIdAsync(id);
            var dto = _mapper.Map<BookDTO>(entity);
            return dto;
        }

        public async Task<BookDTO> Remove(int id)
        {
            var entity = _bookRepository.GetByIdAsync(id).Result;
            var entityResult = await _bookRepository.DeleteAsync(entity);
            var dtoResult = _mapper.Map<BookDTO>(entityResult);
            return dtoResult;
        }

        public async Task<BookDTO> Update(BookDTO dto)
        {
            var entity = _mapper.Map<Domain.Entities.Book>(dto);
            var entityResult = await _bookRepository.UpdateAsync(entity);
            var dtoResult = _mapper.Map<BookDTO>(entityResult);
            return dtoResult;
        }
    }
}