using System.Collections.Generic;

namespace Bookstore.Core.Domain.Entities.Auth
{
    public sealed class Role
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string ConcurrencyStamp { get; set; }

        public ICollection<RoleClaim> RoleClaims { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}