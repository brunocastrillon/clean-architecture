using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Application.DTO
{
    public class LoginDTO
    {
        [EmailAddress(ErrorMessage = "invalid email")]
        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password is required")]
        [StringLength(20, ErrorMessage = "{0} must be at least {2} and at max {1}", MinimumLength = 10)]
        public string Password { get; set; }
    }
}