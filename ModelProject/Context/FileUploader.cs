using Microsoft.AspNetCore.Components.Forms;
using System.IO;

namespace ModelProject.Context
{
    public class FileUploader
    {
        private readonly IWebHostEnvironment _environment;
        //Maximum allowed file size in bytes (5MB) 
        private const long MAX_FILE_SIZE = 1024 * 1024 * 5;
        //types of file allowed to upload 
        private readonly string[] _allowedExtensions = [".jpg", ".jpeg", ".png"];

        public FileUploader(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string?> UploadFileAsync(IBrowserFile file)
        {
            //combines the web root path with subfolders 
            var imagesFolder = Path.Combine(_environment.WebRootPath, "img", "digitalmodels");
            if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);

            //generates a unique file name 
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.Name);
            var filePath = Path.Combine(imagesFolder, fileName);
            var fileExtension = Path.GetExtension(file.Name);

            //rejects models over the MAX_FILE_SIZE (5MB) 
            if (file.Size > MAX_FILE_SIZE) return null;
            if (!_allowedExtensions.Contains(fileExtension)) return null;

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream(MAX_FILE_SIZE).CopyToAsync(stream);

            return fileName;
        }
    }
}