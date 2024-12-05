using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

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
    public async Task<IActionResults> UploadModelFile(IFormFile file)
    {
        if (file = null || file.Length == 0)
        {
            return BadRequest("No file uploaded");
        }
    }
}