using Microsoft.AspNetCore.Http;

namespace Business.Helpers.CommonExtensions;
public static class FileUploadExtension
{
    public static bool CheckFileType(this IFormFile file, string fileType)
        =>file.ContentType.Contains(fileType);
    public static bool CheckFileSize(this IFormFile file, int size)
        => file.Length/1024 < size;
}
