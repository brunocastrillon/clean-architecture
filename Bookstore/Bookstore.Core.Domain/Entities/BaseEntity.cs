using Bookstore.Core.Domain.Validations;

namespace Bookstore.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        public void ValidateId(int id)
        {
            DomainValidationException.When(id < 0, "invalid id");
        }
    }
}