using System.ComponentModel; // Add this
using System.ComponentModel.DataAnnotations;

namespace SportsCapstone.Models
{
    public class LoginViewModel
    {
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [Required(ErrorMessage = "UserName is required.")]
        [DisplayName("Username or Email")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or min 5 letters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}