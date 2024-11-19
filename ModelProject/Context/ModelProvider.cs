using ModelProject.Model;
using SQLitePCL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ModelProject.Context;
using Microsoft.AspNetCore.Components.Forms;
using System;
public class ModelProvider
{
    private readonly DatabaseContext _context;
    private readonly IWebHostEnvironment _environment;
    

    public ModelProvider(DatabaseContext context)
    {
        _context = context;
        _environment = environment;

    }

    public async Task<string> SaveFileAsync(IBrowserFile file)
    {
        var uploadPath = Path.Combine(_environemt.WebRoot, "uploads");
        Directory.CreateDirectory(uploadPath);

        //This creates a file name which is unique 
        var fileName = $"{Guid.NewGuid()}_{file.Name}";
        var filePath = Path.Combine(uploadPath, fileName);

       //This saves the file 
        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.OpenReadStream().CopyToAsync(stream);


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

}
