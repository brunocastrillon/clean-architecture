using Bookstore.Core.Domain.Entities;
using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        #region Auth

            public DbSet<Role> Roles { get; set; }
            public DbSet<RoleClaim> RoleClaims { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<UserClaim> UserClaims { get; set; }
            public DbSet<UserLogin> UserLogins { get; set; }
            public DbSet<UserRole> UserRoles { get; set; }
            public DbSet<UserToken> UserTokens { get; set; } 

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}