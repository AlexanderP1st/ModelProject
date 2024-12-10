using ModelProject.Model;
using Microsoft.EntityFrameworkCore;
using ModelProject.Context;
using Microsoft.AspNetCore.Components.Forms;


public class ModelProvider
{
    private readonly DatabaseContext _context;
    
    public ModelProvider(DatabaseContext context)
    {
        _context = context;
        

    }

    public async Task<List<DigitalModel>> GetModelByUserAsync(User user)
    {
        if (user == null)
        {
            return new List<DigitalModel>();
        }

        return await _context.DigitalModels
            .Where(model => model.User.Id == user.Id)
            .ToListAsync(); 
    }

    public string GetUserByModel(DigitalModel model)
    {
        var users = _context.Users
        .ToDictionary(user => user.Id, user => user.UserName);

        return users[model.User.Id];

    }



    public async Task AddModelAsync(DigitalModel model)
    {
        _context.DigitalModels.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateModelAsync(DigitalModel model)
    {
        _context.DigitalModels.Update(model);
        await _context.SaveChangesAsync();

    }

    public async Task<List<DigitalModel>> GetAllModelsAsync()
    {
        return await _context.DigitalModels.ToListAsync();
    }

    public async Task<DigitalModel?> GetModelByIdAsync(int id)
    {
        return await _context.DigitalModels
                             .Include(m => m.User)
                             .FirstOrDefaultAsync(m => m.Id == id);
    }

    

}
