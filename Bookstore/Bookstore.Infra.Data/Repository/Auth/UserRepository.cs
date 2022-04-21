using Bookstore.Core.Domain.Contracts.Auth;
using Bookstore.Core.Domain.Entities.Auth;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.Infra.Data.Repository.Auth
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        //public async Task<IEnumerable<User>> GetAsync()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        //public async Task<User> GetByIdAsync(int id)
        //{
        //    return await _context.Users.FindAsync(id);
        //}
    }
}