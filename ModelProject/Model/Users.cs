﻿using Microsoft.AspNetCore.Identity;

namespace ModelProject.Model
{
    public class Users : IdentityUser
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

       
       
    }
}
