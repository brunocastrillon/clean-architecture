using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration.Auth
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ClaimType);
            builder.Property(p => p.ClaimValue);

            builder.HasOne(p => p.User).WithMany(p => p.UserClaims).HasForeignKey(p => p.UserId);
        }
    }
}