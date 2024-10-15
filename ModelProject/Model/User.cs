using Microsoft.AspNetCore.Identity;

namespace ModelProject.Model
{
    public class User : IdentityUser
    {
        public string Email { get; set; }

    }
}
