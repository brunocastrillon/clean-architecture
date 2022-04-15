using Bookstore.Core.Domain.Validations;
using System.Collections.Generic;

namespace Bookstore.Core.Domain.Entities
{
    public sealed class Author : BaseEntity
    {
        public string Name { get; private set; }

        public string Bio { get; private set; }

        public ICollection<Book> Books { get; private set; }

        public Author(string name, string bio)
        {
            ValidateDomain(name, bio);
        }

        public Author(int id, string name, string bio)
        {
            ValidateId(id);
            ValidateDomain(name, bio);

            Id = id;
        }

        public void AddBook(Book newBook)
        {
            DomainValidationException.When(newBook is null, "a book is required");

            Books.Add(newBook);
        }

        private void ValidateDomain(string name, string bio)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "name is required");
            DomainValidationException.When(string.IsNullOrEmpty(bio), "bio is required");
            DomainValidationException.When(name.Length < 3, "name too short, min. 3 char");
            DomainValidationException.When(bio.Length < 3, "bio too short, min. 3 char");

            Name = name;
            Bio = bio;
        }
    }
}