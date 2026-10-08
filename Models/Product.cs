using System.ComponentModel.DataAnnotations;

namespace Satiada_Midterm_Store.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";

        [Range(0.01, 1000000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = "";
    }
}
