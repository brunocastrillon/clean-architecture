using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Application.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "UserName is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("First and Last Name")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "invalid email")]
        [Required(ErrorMessage = "email is required")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password is required")]
        [StringLength(20, ErrorMessage = "{0} must be at least {2} and at max {1}", MinimumLength = 10)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}