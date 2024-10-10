namespace ModelProject.Model
{
    public class Model
    {
        public int ID { get; set; }
        
        public string Title { get; set; } 

        public string Catagory { get; set; } 

        public string Description { get; set; }

        public string Specifications { get; set; } 

        public Users UserID { get; set; } 

        public int Downloads { get; set; } 

        public float FileSize { get; set; } 


    }
}
