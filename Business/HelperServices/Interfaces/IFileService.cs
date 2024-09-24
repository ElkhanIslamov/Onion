using Microsoft.AspNetCore.Http;

namespace Business.HelperServices.Interfaces;
public interface IFileService
{
    Task<string> UploadAsync(IFormFile file, string fileType, int fileSize);
}
