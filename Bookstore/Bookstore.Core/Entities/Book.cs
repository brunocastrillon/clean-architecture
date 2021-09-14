using Bookstore.SharedKernel;
using Bookstore.SharedKernel.Interfaces;

namespace Bookstore.Core.Entities
{
    public class Book : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }

        public Book(string title)
        {
            Title = title;
        }
    }
