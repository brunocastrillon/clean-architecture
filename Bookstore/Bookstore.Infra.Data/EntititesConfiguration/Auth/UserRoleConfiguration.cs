using Bookstore.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration.Auth
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(p => p.UserId);
            builder.HasKey(p => p.RoleId);

            builder.HasOne(p => p.User).WithMany(p => p.UserRoles).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Role).WithMany(p => p.UserRoles).HasForeignKey(p => p.RoleId);
        }
    }
}