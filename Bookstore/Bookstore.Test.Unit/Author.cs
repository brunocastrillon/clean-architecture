using Bookstore.Core.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Bookstore.Test.Unit
{
    public class Author
    {
        [Fact(DisplayName = "Create author should not throw domain validation exception")]
        public void CreateWithValidState()
        {
            Action action = () => new Core.Domain.Entities.Author("author-001", "author-bio-001");
            action.Should().NotThrow<Core.Domain.Validations.DomainValidationException>();
        }

        [Fact(DisplayName = "Create author should throw domain validate exception with invalid id")]
        public void CreateWithInvalidId()
        {
            Action action = () => new Core.Domain.Entities.Author(-1, "author-001", "author-bio-001");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("invalid id");
        }

        [Fact(DisplayName = "Create author should throw domain validate exception with name too short")]
        public void CreateWithInvalidName()
        {
            Action action = () => new Core.Domain.Entities.Author("ca", "author-bio-001");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("name too short, min. 3 char");
        }

        [Fact(DisplayName = "Create author should throw domain validate exception with name is required")]
        public void CreateWithMissingName()
        {
            Action action = () => new Core.Domain.Entities.Author(string.Empty, "author-bio-001");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("name is required");
        }

        [Fact(DisplayName = "Create author should throw domain validate exception with bio too short")]
        public void CreateWithInvalidBio()
        {
            Action action = () => new Core.Domain.Entities.Author("author-001", "au");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("bio too short, min. 3 char");
        }

        [Fact(DisplayName = "Create author should throw domain validate exception with bio is required")]
        public void CreateWithMissingBio()
        {
            Action action = () => new Core.Domain.Entities.Author("author-001", string.Empty);
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("bio is required");
        }

        [Fact(DisplayName = "Add new book should not throw domain validation exception")]
        public void AddBook()
        {
            Core.Domain.Entities.Author author = new("JRR Token", "the best");
            Core.Domain.Entities.Book newBook = new("The Silmarillion", "the best", "1970");
            author.AddBook(newBook);
            Assert.Contains(newBook, author.Books);
        }

        [Fact(DisplayName = "Add new book should throw domain validate exception with a book is required")]
        public void AddBookWithNullBook()
        {
            Core.Domain.Entities.Author author = new("JRR Token", "the best");
            Action action = () => author.AddBook(null);
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("a book is required");
        }
    }
}