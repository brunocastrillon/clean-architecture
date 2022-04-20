using Bookstore.Core.Application.DTO;
using Bookstore.Core.Application.Services.Book;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Interface.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> Get()
        {
            var dtos = await _bookService.Get();

            if (dtos == null) return NoContent();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> Get(int id)
        {
            var dto = await _bookService.GetById(id);

            if (dto == null) return NoContent();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookDTO dto)
        {
            if (dto == null) return BadRequest("invalid data");

            var resultDTO = await _bookService.Add(dto);

            return Ok(resultDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BookDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            if (dto == null) return BadRequest();

            var resultDTO = await _bookService.Update(dto);

            return Ok(resultDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDTO>> Delete(int id)
        {
            var dto = await _bookService.GetById(id);

            if (dto == null) return NoContent();

            var resultDTO = await _bookService.Remove(id);

            return Ok(resultDTO);
        }
    }
}