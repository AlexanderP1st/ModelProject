using ModelProject.Model;
using SQLitePCL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ModelProject.Context;
public class ModelProvider
{
    private readonly List<DigitalModel> models = new();

    private readonly DatabaseContext _context; 
    public void AddModelAsync(DigitalModel model)
    {
        models.Add(model); 
    }
    
    public ModelProvider(DatabaseContext context)
    {
        _context = context; 
    }

    public async Task UpdateCheeseAsync(DigitalModel model)
    {
        _context.DigitalModels.Update(model);

    }
    
    public List<DigitalModel> GetAllModels()
    {
        return models; 
    }

  
}
