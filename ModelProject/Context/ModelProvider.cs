using ModelProject.Model;
using SQLitePCL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ModelProject.Context;
public class ModelProvider
{
    private readonly DatabaseContext _context;

    public ModelProvider(DatabaseContext context)
    {
        _context = context;
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


   
}
