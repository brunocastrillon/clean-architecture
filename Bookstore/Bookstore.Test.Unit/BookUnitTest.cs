using Bookstore.Core.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Bookstore.Test.Unit
{
    public class BookUnitTest
    {
        [Fact(DisplayName = "Create book with valid state")]
        public void CreateBook_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Book("book-001", "description", "2000");
            action.Should().NotThrow<Core.Domain.Validations.DomainValidationException>();
        }

        [Fact(DisplayName = "Create book with invalid id")]
        public void CreateBook_WithInvalidId_ResultObjectInvalidId()
        {
            Action action = () => new Book(-1, "book-001", "description", "2000");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("invalid id");
        }

        [Fact(DisplayName = "Create book with invalid description")]
        public void CreateBook_WithInvalidDescription_ResultObjectInvalidDescription()
        {
            Action action = () => new Book(1, "book-001", "ca", "2000");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("description too short, min. 3 char");
        }

        [Fact(DisplayName = "Create book with missing description")]
        public void CreateBook_WithMissingDescription_ResultObjectMissingDescription()
        {
            Action action = () => new Book(1, "book", string.Empty, "2000");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("description is required");
        }
    }
}