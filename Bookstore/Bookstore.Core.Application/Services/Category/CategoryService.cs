using AutoMapper;
using Bookstore.Core.Application.DTO;
using Bookstore.Core.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Core.Application.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Add(CategoryDTO dto)
        {
            var entity = _mapper.Map<Domain.Entities.Category>(dto);
            var entityResult = await _categoryRepository.CreateAsync(entity);
            var dtoResult = _mapper.Map<CategoryDTO>(entityResult);
            return dtoResult;
        }

        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            var entity = await _categoryRepository.GetAsync();
            var dto = _mapper.Map<IEnumerable<CategoryDTO>>(entity);
            return dto;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            var dto = _mapper.Map<CategoryDTO>(entity);
            return dto;
        }

        public async Task<CategoryDTO> Remove(int id)
        {
            var entity = _categoryRepository.GetByIdAsync(id).Result;
            var entityResult = await _categoryRepository.DeleteAsync(entity);
            var dtoResult = _mapper.Map<CategoryDTO>(entityResult);
            return dtoResult;
        }

        public async Task<CategoryDTO> Update(CategoryDTO dto)
        {
            var entity = _mapper.Map<Domain.Entities.Category>(dto);
            var entityResult = await _categoryRepository.UpdateAsync(entity);
            var dtoResult = _mapper.Map<CategoryDTO>(entityResult);
            return dtoResult;
        }
    }
}