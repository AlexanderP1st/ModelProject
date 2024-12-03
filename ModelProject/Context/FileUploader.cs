using Microsoft.AspNetCore.Components.Forms;

public class FileUploader
{
    private readonly IWebHostEnvironment _environment;
    private const long MAX_FILE_SIZE = 1024 * 1024 * 1024 * 5;
    private readonly string[] _allowedExtentions = [".jpg", ".jpeg", ".png"]; 

    public FileUploader(IWebHostEnvironment environment)
    {
        _environment = environment; 
    }

    public async Task<string?> UploadFileAsync(IBrowserFile file)
    {
        var imageFolder = Path.Combine(_environment.WebRootPath, "img", "digitalmodels");
        if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);


        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.Name); 
    }
}//KEEP WORKING ON THIS 