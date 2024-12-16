using Microsoft.AspNetCore.Identity;

namespace ModelProject.Model
{
    public class User : IdentityUser
    {
        //creates a new user
        public string Email { get; set; }

        //creates a field which holds the users last downloaded category
        public string? LastDownloadedCategory { get; set; } 
    }
}
