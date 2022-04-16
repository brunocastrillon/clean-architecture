using AutoMapper;
using Bookstore.Core.Application.DTO;
using Bookstore.Core.Domain.Contracts;
using System;
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

        public Task<IEnumerable<CategoryDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}