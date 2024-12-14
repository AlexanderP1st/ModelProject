using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelProject.Model;

namespace ModelProject.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;

        public UserProvider(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }
        public User? GetUserByUsername(string? username)
        {
            //returns the user with the specified username
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }

        public async Task<User?> GetUserByIdAsync(string? id)
        {
            return await _context.Users.FindAsync(id); 
        }
    }
}
