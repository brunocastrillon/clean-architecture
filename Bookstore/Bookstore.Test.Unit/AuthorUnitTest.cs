using Bookstore.Core.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Bookstore.Test.Unit
{
    public class AuthorUnitTest
    {
        [Fact(DisplayName = "Create author with valid state")]
        public void CreateAuthor_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Author("author-001", "author-bio-001");
            action.Should().NotThrow<Core.Domain.Validations.DomainValidationException>();
        }

        [Fact(DisplayName = "Create author with invalid id")]
        public void CreateAuthor_WithInvalidId_ResultObjectInvalidId()
        {
            Action action = () => new Author(-1, "author-001", "author-bio-001");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("invalid id");
        }

        [Fact(DisplayName = "Create author with invalid name")]
        public void CreateAuthor_WithInvalidName_ResultObjectInvalidName()
        {
            Action action = () => new Author("ca", "author-bio-001");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("name too short, min. 3 char");
        }

        [Fact(DisplayName = "Create category with missing name")]
        public void CreateCategory_WithMissingName_ResultObjectMissingName()
        {
            Action action = () => new Author("", "author-bio-001");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("name is required");
        }
    }
}