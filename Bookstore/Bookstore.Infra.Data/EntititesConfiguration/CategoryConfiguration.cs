using Bookstore.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.EntititesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.HasMany(p => p.Books).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            //TODO: comentar essa linha: popular a tabela 'category' no momento da migração
            builder.HasData(new Category(1, "category-001"), new Category(2, "category-002"), new Category(3, "category-003"));
        }
    }
}