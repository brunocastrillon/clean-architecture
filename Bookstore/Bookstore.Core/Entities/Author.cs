using Bookstore.SharedKernel;
using Bookstore.SharedKernel.Interfaces;

namespace Bookstore.Core.Entities
{
    public class Author : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public Author(string name)
        {
            Name = name;
        }
    }
}