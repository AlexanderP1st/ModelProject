using System.ComponentModel.DataAnnotations;

namespace ModelProject.Model
{
    public class DigitalModel
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required(ErrorMessage = "Model title is required.")]
        [StringLength(15, ErrorMessage = "Title cannot exceed 15 characters.")]
        public string Title { get; set; }


        [Required(ErrorMessage = "At least one model file required")]
        [MinLength(1, ErrorMessage = "Please upload at least one model file.")]
        public string ModelFiles { get; set; }

        [Required(ErrorMessage = "An image file is required.")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Specifications are required.")]
        [StringLength(500, ErrorMessage = "Specifications cannot exceed 500 characters..")]
        public string Specifications { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Downloads cannot be negative.")]
        public int Downloads { get; set; }


        
        public string FileSize { get; set; }
    }
}