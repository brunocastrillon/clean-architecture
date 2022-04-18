using Bookstore.Core.Application.DTO;
using Bookstore.Core.Application.Services.Author;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Interface.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> Get()
        {
            var dtos = await _authorService.Get();

            if (dtos == null) return NoContent();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> Get(int id)
        {
            var dto = await _authorService.GetById(id);

            if (dto == null) return NoContent();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorDTO dto)
        {
            if (dto == null) return BadRequest("invalid Data");

            var resultDTO = await _authorService.Add(dto);

            return Ok(resultDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AuthorDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            if (dto == null) return BadRequest();

            var resultDTO = await _authorService.Update(dto);

            return Ok(resultDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorDTO>> Delete(int id)
        {
            var dto = await _authorService.GetById(id);

            if (dto == null) return NoContent();

            var resultDTO = await _authorService.Remove(id);

            return Ok(resultDTO);
        }
    }
}