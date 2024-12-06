using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using ModelProject.Model;
using SQLitePCL;
using System.IO;
using ModelProject.Context;

public class ModelFileProvider
{
    private readonly string uploadsFolder;
    private readonly DatabaseContext _context;


    public ModelFileProvider(DatabaseContext context)
    {
        _context = context; 
    }

    public ModelFileProvider()
    {
        uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/models");
        Directory.CreateDirectory(uploadsFolder);
    }

    public async Task<string> SaveModelFileAsync(IBrowserFile file)
    {
        var filePath = Path.Combine(uploadsFolder, file.Name);
        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.OpenReadStream(maxAllowedSize: 1024 * 1024 * 50).CopyToAsync(stream);
        return $"uploads/models/{file.Name}";
    }

    public string GetDownloadLink(string relativePath)
    {
        return $"/{relativePath}";
    }
    
    public async Task AddModelAsync(DigitalModel model)
    {
        _context.DigitalModels.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task<DigitalModel?> GetModelByIdAsync(int id)
    {
        return await _context.DigitalModels.FindAsync(id);
    }

    public async Task UpdateModelAsync(DigitalModel model)
    {
        _context.DigitalModels.Update(model);
        await _context.SaveChangesAsync(); 

    }
}