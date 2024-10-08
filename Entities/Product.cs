using System.ComponentModel.DataAnnotations;

namespace SportsCapstone.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Quantity should not be empty")]
        [Range(1, 100, ErrorMessage = "Product should not be more than 100")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Type of Product is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Type of Age is required.")]
        [Range(1, 60, ErrorMessage = "Age should not be more than 60")]
        public string AgeRange { get; set; }
    }
}
