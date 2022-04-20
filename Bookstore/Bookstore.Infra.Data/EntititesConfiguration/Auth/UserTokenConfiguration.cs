using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration.Auth
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(p => p.UserId);
            builder.HasKey(p => p.LoginProvider);
            builder.HasKey(p => p.Name);

            builder.Property(p => p.Value);

            builder.HasOne(p => p.User).WithMany(p => p.UserTokens).HasForeignKey(p => p.UserId);
        }
    }
}