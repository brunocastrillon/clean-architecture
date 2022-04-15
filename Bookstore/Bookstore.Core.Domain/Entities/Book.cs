using Bookstore.Core.Domain.Validations;

namespace Bookstore.Core.Domain.Entities
{
    public sealed class Book : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string PublicationYear { get; private set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Book(string title, string description, string publicationYear)
        {
            ValidateDomain(title, description, publicationYear);
        }

        public Book(int id, string title, string description, string publicationYear)
        {
            ValidateId(id);
            ValidateDomain(title, description, publicationYear);
            
            Id = id;
        }

        private void ValidateDomain(string title, string description, string publicationYear)
        {
            DomainValidationException.When(string.IsNullOrEmpty(title), "title is required");
            DomainValidationException.When(string.IsNullOrEmpty(description), "description is required");
            DomainValidationException.When(string.IsNullOrEmpty(publicationYear), "publicationYear is required");
            DomainValidationException.When(title.Length < 3, "name too short, min. 3 char");
            DomainValidationException.When(description.Length < 3, "bio too short, min. 3 char");
            DomainValidationException.When(publicationYear.Length < 4, "bio too short, min. 4 char");

            Title = title;
            Description = description;
            PublicationYear = publicationYear;
        }
    }
}