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

        public async Task Add(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Domain.Entities.Category>(categoryDTO);
            await _categoryRepository.CreateAsync(category);
        }

        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            var categories = await _categoryRepository.GetAsync();
            var mapped = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return mapped;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var mapped = _mapper.Map<CategoryDTO>(category);
            return mapped;
        }

        public async Task Remove(int id)
        {
            var category = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Domain.Entities.Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}