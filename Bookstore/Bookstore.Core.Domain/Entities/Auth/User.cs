using System.Collections.Generic;

namespace Bookstore.Core.Domain.Entities.Auth
{
    public sealed class User
    {
        public string Id { get; set; }
        
        public string UserName { get; set; }
        
        public string NormalizedUserName { get; set; }
        
        public string Email { get; set; }
        
        public string NormalizedEmail { get; set; }
        
        public int EmailConfirmed { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string SecurityStamp { get; set; }
        
        public string ConcurrencyStamp { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public int PhoneNumberConfirmed { get; set; }
        
        public int TwoFactorEnabled { get; set; }
        
        public string LockoutEnd { get; set; }
        
        public int LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<UserClaim> UserClaims { get; set; }

        public ICollection<UserToken> UserTokens { get; set; }

        public ICollection<UserLogin> UserLogins { get; set; }
    }
}