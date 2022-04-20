using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration.Auth
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(p => p.LoginProvider);
            builder.HasKey(p => p.ProviderKey);

            builder.Property(p => p.ProviderDisplayName);

            builder.HasOne(p => p.User).WithMany(p => p.UserLogins).HasForeignKey(p => p.UserId);
        }
    }
}
