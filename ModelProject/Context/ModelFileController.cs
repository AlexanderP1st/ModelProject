using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

[ApiController]
[Route("api/[controller")]
public class ModelFileController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public ModelFileController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    [HttpPost("upload")]
    public async Task<IActionResult> UploadModelFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded");
        }
        var filePath = Path.Combine(_environment.WebRootPath, "uploads", file.FileName);
        using  (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return Ok(new { FilePath = filePath });
    }
    [HttpGet ("download/{filename}")]
    public IActionResult DownloadModelFile(string filename)
    {
        var filePath = Path.Combine(_environment.WebRootPath, "upload", filename);
        
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "application/octet-stream", filename);
    }
}