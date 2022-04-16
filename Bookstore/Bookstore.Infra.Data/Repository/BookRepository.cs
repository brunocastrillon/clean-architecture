using Bookstore.Core.Domain.Contracts;
using Bookstore.Core.Domain.Entities;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
    }
}