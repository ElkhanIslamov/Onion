using Business.Exceptions.FileExceptions;
using Business.Helpers.CommonExtensions;
using Business.HelperServices.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.HelperServices.Implementations;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> UploadAsync(IFormFile file, string fileType, int fileSize)
    {
        if (!file.CheckFileType(fileType))
            throw new FileTypeException($"File type must be {fileType}");
        if (!file.CheckFileSize(fileSize))
            throw new FileSizeException($"File size exceeded {fileSize}");

        string fileName = $"{Guid.NewGuid()}-{file.FileName}";
        string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

        using(FileStream stream = new FileStream(path,FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return fileName;

    }
}
