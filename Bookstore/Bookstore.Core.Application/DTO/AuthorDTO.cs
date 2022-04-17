using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Application.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "bio is required")]
        [MinLength(3)]
        [MaxLength(300)]
        [DisplayName("Bio")]
        public string Bio { get; private set; }
    }
}