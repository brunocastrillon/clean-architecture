using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration.Auth
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserName).IsRequired();
            builder.Property(p => p.NormalizedUserName);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.NormalizedEmail);
            builder.Property(p => p.EmailConfirmed);//.IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.SecurityStamp);
            builder.Property(p => p.ConcurrencyStamp);
            builder.Property(p => p.PhoneNumber);
            builder.Property(p => p.PhoneNumberConfirmed);//.IsRequired();
            builder.Property(p => p.TwoFactorEnabled);//.IsRequired();
            builder.Property(p => p.LockoutEnd);
            builder.Property(p => p.LockoutEnd);//.IsRequired();
            builder.Property(p => p.AccessFailedCount);//.IsRequired();

            builder.HasMany(p => p.UserRoles).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            builder.HasMany(p => p.UserClaims).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            builder.HasMany(p => p.UserTokens).WithOne(p => p.User).HasForeignKey(p => p.UserId);
            builder.HasMany(p => p.UserLogins).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        }
    }
}