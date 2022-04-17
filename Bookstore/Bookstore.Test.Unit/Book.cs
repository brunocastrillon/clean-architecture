using Bookstore.Core.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Bookstore.Test.Unit
{
    public class Book
    {
        [Fact(DisplayName = "Create book should not throw domain validation exception")]
        public void CreateWithValidState()
        {
            Action action = () => new Core.Domain.Entities.Book("book-001", "description", "2000");
            action.Should().NotThrow<Core.Domain.Validations.DomainValidationException>();
        }

        [Fact(DisplayName = "Create book should throw domain validate exception with invalid id")]
        public void CreateWithInvalidId()
        {
            Action action = () => new Core.Domain.Entities.Book(-1, "book-001", "description", "2000");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("invalid id");
        }

        [Fact(DisplayName = "Create book should throw domain validate exception with description too short")]
        public void CreateWithInvalidDescription()
        {
            Action action = () => new Core.Domain.Entities.Book(1, "book-001", "ca", "2000");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("description too short, min. 3 char");
        }

        [Fact(DisplayName = "Create book should throw domain validate exception with description is required")]
        public void CreateWithMissingDescription()
        {
            Action action = () => new Core.Domain.Entities.Book(1, "book", string.Empty, "2000");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("description is required");
        }

        [Fact(DisplayName = "Create book should throw domain validate exception with publicationYear too short")]
        public void CreateWithInvalidPublicationYear()
        {
            Action action = () => new Core.Domain.Entities.Book(1, "book-001", "description", "200");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("publicationYear too short, min. 4 char");
        }

        [Fact(DisplayName = "Create book should throw domain validate exception with publicationYear is required")]
        public void CreateWithMissingPublicationYear()
        {
            Action action = () => new Core.Domain.Entities.Book(1, "book", "description", string.Empty);
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("publicationYear is required");
        }
    }
}