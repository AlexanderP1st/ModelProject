using Microsoft.AspNetCore.Identity;

namespace ModelProject.Model
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Email { get; set; }

    }
}
