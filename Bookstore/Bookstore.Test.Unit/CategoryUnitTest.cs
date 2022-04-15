using Bookstore.Core.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Bookstore.Test.Unit
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category("category-001");
            action.Should().NotThrow<Core.Domain.Validations.DomainValidationException>();
        }

        [Fact(DisplayName = "Create category with invalid id")]
        public void CreateCategory_WithInvalidId_ResultObjectInvalidId()
        {
            Action action = () => new Category(-1, "category-001");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("invalid id");
        }

        [Fact(DisplayName = "Create category with invalid description")]
        public void CreateCategory_WithInvalidDescription_ResultObjectInvalidDescription()
        {
            Action action = () => new Category(1, "ca");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("description too short, min. 3 char");
        }

        [Fact(DisplayName = "Create category with missing description")]
        public void CreateCategory_WithMissingDescription_ResultObjectMissingDescription()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("description is required");
        }
    }
}