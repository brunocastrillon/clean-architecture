using Bookstore.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(300).IsRequired();
            builder.Property(p => p.PublicationYear).HasMaxLength(4).IsRequired();

            builder.HasOne(p => p.Author).WithMany(p => p.Books).HasForeignKey(p => p.AuthorId);
            builder.HasOne(p => p.Category).WithMany(p => p.Books).HasForeignKey(p => p.CategoryId);
        }
    }
}
