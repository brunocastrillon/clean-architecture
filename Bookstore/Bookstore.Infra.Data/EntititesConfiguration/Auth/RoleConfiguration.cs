using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration.Auth
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name);
            builder.Property(p => p.NormalizedName);
            builder.Property(p => p.ConcurrencyStamp);

            builder.HasMany(p => p.RoleClaims).WithOne(p => p.Role).HasForeignKey(p => p.RoleId);
        }
    }
}