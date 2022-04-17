using AutoMapper;
using Bookstore.Core.Application.DTO;
using Bookstore.Core.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task Add(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Domain.Entities.Author>(authorDTO);
            await _authorRepository.CreateAsync(author);
        }

        public async Task<IEnumerable<AuthorDTO>> Get()
        {
            var authors = await _authorRepository.GetAsync();
            var mapped = _mapper.Map<IEnumerable<AuthorDTO>>(authors);
            return mapped;
        }

        public async Task<AuthorDTO> GetById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            var mapped = _mapper.Map<AuthorDTO>(author);
            return mapped;
        }

        public async Task Remove(int id)
        {
            var author = _authorRepository.GetByIdAsync(id).Result;
            await _authorRepository.DeleteAsync(author);
        }

        public async Task Update(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Domain.Entities.Author>(authorDTO);
            await _authorRepository.UpdateAsync(author);
        }
    }
}