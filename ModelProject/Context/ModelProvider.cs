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

       public async Task<List<DigitalModel>> GetAllModelsAsync()
       {
        return await _context.DigitalModels.OrderBy(digitalModel => digitalModel.Title).ToListAsync();
       }

       public async Task AddModelAsync(DigitalModel Models)
       {
        _context.DigitalModels.Add(Models);
        await _context.SaveChangesAsync();
       }

        public async Task UpdateModelAsync(DigitalModel Models)
        {
        _context.DigitalModels.Update(Models);
        await _context.SaveChangesAsync();

        }

       



}

