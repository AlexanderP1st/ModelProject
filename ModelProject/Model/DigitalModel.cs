using System.ComponentModel.DataAnnotations;

namespace ModelProject.Model
{
    public class DigitalModel
    {
        public int Id { get; set; }

        public User User { get; set; }

        [Required]
       
        public string Title { get; set; }

        [Required]
        public string[] ModelFiles { get; set; }

        [Required]
        public string[] Images { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        
        public string Description { get; set; }

        [Required]
        public string Specifications { get; set; }

        public int Downloads { get; set; }

        public int FileSize { get; set; }
    }
}
