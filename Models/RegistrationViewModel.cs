using System.ComponentModel.DataAnnotations;

namespace SportsCapstone.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [Required(ErrorMessage = "LastName name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or min 5 letters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password. ")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}