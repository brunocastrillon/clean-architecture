using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "title is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "description is required")]
        [MinLength(3)]
        [MaxLength(300)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "publication year is required")]
        [MinLength(4)]
        [MaxLength(4)]
        [DisplayName("Publication Year")]
        public string PublicationYear { get; set; }
    }
}