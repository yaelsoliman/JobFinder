using JobFinder.Infrastructure.Shared;
using Microsoft.Extensions.Hosting;

namespace JobFinder.Helper;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public FileService(IWebHostEnvironment hostEnvironment) => _hostEnvironment = hostEnvironment;

    public async Task<string?> UploadFileAsync(IFormFile file, string location)
    {
        try
        {
            if (file is null)
                return null;

            string uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, $"DataContent/{location}");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            var fileExtantion = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtantion}";
            string filePath = Path.Combine(uploadFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            filePath = filePath.Replace(_hostEnvironment.WebRootPath, "");
            return filePath.Replace(@"\", "/");
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
