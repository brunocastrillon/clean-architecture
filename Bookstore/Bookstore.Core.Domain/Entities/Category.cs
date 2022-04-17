using Bookstore.Core.Domain.Validations;
using System.Collections.Generic;

namespace Bookstore.Core.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Description { get; private set; }

        public ICollection<Book> Books { get; set; }

        public Category(string description)
        {
            ValidateDomain(description);
        }

        public Category(int id, string description)
        {
            ValidateId(id);
            ValidateDomain(description);

            Id = id;
        }

        private void ValidateDomain(string description)
        {
            DomainValidationException.When(string.IsNullOrEmpty(description), "description is required");
            DomainValidationException.When(description.Length < 3, "description too short, min. 3 char");

            Description = description;
        }
    }
}