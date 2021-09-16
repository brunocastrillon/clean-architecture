using System.ComponentModel.DataAnnotations;

namespace Bookstore.API.DTO
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public static Book FromBooks(Core.Entities.Book book)
        {
            return new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description
            };
        }
    }
}