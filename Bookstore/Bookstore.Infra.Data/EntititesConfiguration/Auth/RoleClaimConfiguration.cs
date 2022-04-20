using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration.Auth
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ClaimType);
            builder.Property(p => p.ClaimValue);

            builder.HasOne(p => p.Role).WithMany(p => p.RoleClaims).HasForeignKey(p => p.RoleId);
        }
    }
}