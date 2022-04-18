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

        public async Task<AuthorDTO> Add(AuthorDTO dto)
        {
            var entity = _mapper.Map<Domain.Entities.Author>(dto);
            var entityResult = await _authorRepository.CreateAsync(entity);
            var dtoResult = _mapper.Map<AuthorDTO>(entityResult);
            return dtoResult;
        }

        public async Task<IEnumerable<AuthorDTO>> Get()
        {
            var entity = await _authorRepository.GetAsync();
            var dto = _mapper.Map<IEnumerable<AuthorDTO>>(entity);
            return dto;
        }

        public async Task<AuthorDTO> GetById(int id)
        {
            var entity = await _authorRepository.GetByIdAsync(id);
            var dto = _mapper.Map<AuthorDTO>(entity);
            return dto;
        }

        public async Task<AuthorDTO> Remove(int id)
        {
            var entity = _authorRepository.GetByIdAsync(id).Result;
            var entityResult = await _authorRepository.DeleteAsync(entity);
            var dtoResult = _mapper.Map<AuthorDTO>(entityResult);
            return dtoResult;
        }

        public async Task<AuthorDTO> Update(AuthorDTO dto)
        {
            var entity = _mapper.Map<Domain.Entities.Author>(dto);
            var entityResult = await _authorRepository.UpdateAsync(entity);
            var dtoResult = _mapper.Map<AuthorDTO>(entityResult);
            return dtoResult;
        }
    }
}