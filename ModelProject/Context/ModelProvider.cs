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

    public async Task<string> SaveFileAsync(IBrowserFile file)
    {
        var fileName = $"{Guid.NewGuid()}_{file.Name}";


        var uploadPath = Path.Combine(_context.GetWebRootPath(), "uploads");

        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath); 
        }
        var filePath = Path.Combine(uploadPath, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.OpenReadStream().CopyToAsync(fileStream);
        }

        return $"/uploads/{fileName}"; 

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

    public async Task<List<DigitalModel>> GetUserModelsAsync(string userId)
    {
        return await _context.DigitalModels
            .Where(mbox => mbox.User.Id == userId)
            .ToListAsync(); 
    }

}
