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
            var books = await _bookService.Get();

            if (books == null) return NotFound("books not found");

            return Ok(books);
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult<BookDTO>> Get(int id)
        {
            var book = await _bookService.GetById(id);

            if (book == null) return NotFound("book not found");

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookDTO dto)
        {
            if (dto == null) return BadRequest("Invalid Data");

            await _bookService.Add(dto);

            return new CreatedAtRouteResult("GetById", new { id = dto.Id }, dto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] BookDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            if (dto == null) return BadRequest();

            await _bookService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BookDTO>> Delete(int id)
        {
            var book = await _bookService.GetById(id);

            if (book == null) return NotFound("book not found");

            await _bookService.Remove(id);

            return Ok(book);
        }
    }
}