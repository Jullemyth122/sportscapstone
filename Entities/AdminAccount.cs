using System.ComponentModel.DataAnnotations;

namespace SportsCapstone.Entities
{
    public class AdminAccount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [Required(ErrorMessage = "LastName name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
