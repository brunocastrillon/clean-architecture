using Bookstore.Core.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Bookstore.Test.Unit
{
    public class Category
    {
        [Fact(DisplayName = "Create category should not throw domain validation exception")]
        public void CreateWithValidState()
        {
            Action action = () => new Core.Domain.Entities.Category("category-001");
            action.Should().NotThrow<Core.Domain.Validations.DomainValidationException>();
        }

        [Fact(DisplayName = "Create category should throw domain validate exception with invalid id")]
        public void CreateWithInvalidId()
        {
            Action action = () => new Core.Domain.Entities.Category(-1, "category-001");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("invalid id");
        }

        [Fact(DisplayName = "Create book should throw domain validate exception with description too short")]
        public void CreateWithInvalidDescription()
        {
            Action action = () => new Core.Domain.Entities.Category(1, "ca");
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("description too short, min. 3 char");
        }

        [Fact(DisplayName = "Create book should throw domain validate exception with description is required")]
        public void CreateWithMissingDescription()
        {
            Action action = () => new Core.Domain.Entities.Category(1, string.Empty);
            action.Should().Throw<Core.Domain.Validations.DomainValidationException>().WithMessage("description is required");
        }
    }
}