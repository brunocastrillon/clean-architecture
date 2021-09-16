using Bookstore.SharedKernel;

namespace Bookstore.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Book(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}