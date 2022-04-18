using Bookstore.Core.Application.DTO;
using Bookstore.Core.Application.Services.Category;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Interface.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var dtos = await _categoryService.Get();

            if (dtos == null) return NoContent();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var dto = await _categoryService.GetById(id);
            
            if (dto == null) return NoContent();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO dto)
        {
            if (dto == null) return BadRequest("invalid data");

            var resultDTO = await _categoryService.Add(dto);

            return Ok(resultDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            if (dto == null) return BadRequest();

            var resultDTO = await _categoryService.Update(dto);

            return Ok(resultDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var dto = await _categoryService.GetById(id);

            if (dto == null) return NoContent();

            var resultDTO = await _categoryService.Remove(id);

            return Ok(resultDTO);
        }
    }
}