using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "description is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}