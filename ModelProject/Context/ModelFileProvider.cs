using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;

public class ModelFileProvider
 {
    private readonly HttpClient httpClient;
    private HttpClient _httpClient;

    public ModelFileProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task UploadModelAsync(IBrowserFile file, string uploadUrl)
    {
        using (var content = new MultipartFormDataContent())
        {
            var fileContent = new StreamContent(file.OpenReadStream());
            content.Add(fileContent, "file", file.Name);

            var response = await _httpClient.PostAsync(uploadUrl, content);
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("File upload failed"); 
            }
        }
    }
    public async Task DownloadFileAsync(string fileUrl)
    {
        var response = await _httpClient.GetAsync(fileUrl);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("File download failed");
        }
        var fileContent = await response.Content.ReadAsStringAsync();
    }
}

  