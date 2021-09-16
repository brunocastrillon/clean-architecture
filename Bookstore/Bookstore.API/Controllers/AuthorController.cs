using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bookstore.SharedKernel.Interfaces;
using Author = Bookstore.Core.AuthorAggregate.Author;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IRepository<Author> _author;

        public AuthorController(ILogger<AuthorController> logger, IRepository<Author> author)
        {
            _logger = logger;
            _author = author;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var DTO = (await _author.List()).Select(author => new DTO.Author
            {
                Id = author.Id,
                Name = author.Name
            }).ToList();

            return Ok(DTO);
        }
    }
}