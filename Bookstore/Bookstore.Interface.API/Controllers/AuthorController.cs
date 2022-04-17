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
            var authors = await _authorService.Get();

            if (authors == null) return NotFound("authors not found");

            return Ok(authors);
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult<AuthorDTO>> Get(int id)
        {
            var author = await _authorService.GetById(id);

            if (author == null) return NotFound("author not found");

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorDTO dto)
        {
            if (dto == null) return BadRequest("Invalid Data");

            await _authorService.Add(dto);

            return new CreatedAtRouteResult("GetById", new { id = dto.Id }, dto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] AuthorDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            if (dto == null) return BadRequest();

            await _authorService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AuthorDTO>> Delete(int id)
        {
            var author = await _authorService.GetById(id);

            if (author == null) return NotFound("author not found");

            await _authorService.Remove(id);

            return Ok(author);
        }
    }
}