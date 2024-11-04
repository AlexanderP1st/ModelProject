using Microsoft.AspNetCore.Identity;

namespace ModelProject.Model
{
    public class User : IdentityUser
    {
        //creates a new user
        public string Email { get; set; }

    }
}
