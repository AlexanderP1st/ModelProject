using System.ComponentModel.DataAnnotations;

namespace ModelProject.Model
{
    public class DigitalModel
    {
        public int Id { get; set; }

        public User User { get; set; }


        public string Title { get; set; }
        
        public string ModelFiles { get; set; }

        
        public string? ImageUrl { get; set; }

      
        public string Category { get; set; }

        public string FileFormat { get; set; } 

        public string Description { get; set; }

        public string Specifications { get; set; }

        public int Downloads { get; set; }

        //creates a watchlist field which is responsable to counting the amount of people who have seen a specific model.
        public int WatchListCount { get; set; }

        public DateTime DateUploaded { get; set; }
    }
}