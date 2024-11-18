using ModelProject.Model;
using Microsoft.EntityFrameworkCore;
using ModelProject.Context;



public class ModelProvider
{
    private readonly DatabaseContext _context;

    public ModelProvider(DatabaseContext context)
    {
      _context = context;
    }

    public async Task AddModelAsync(DigitalModel digitalModel)
    {
        _context.DigitalModels.Add(digitalModel);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateModelAsync(DigitalModel digitalModels)
    {
        _context.DigitalModels.Update(digitalModels);
        await _context.SaveChangesAsync();

    }

    public async Task<List<DigitalModel>> GetAllModelsAsync()
    {
        return await _context.DigitalModels.OrderBy(digitalModel => digitalModel.Title).ToListAsync();
    }



}

