using System.Net;

namespace Business.Exceptions.FileExceptions;

public class FileTypeException : Exception, IBaseException
{
    public FileTypeException(string message):base(message)
    {
        ErrorMessage = message;
    }
    public string ErrorMessage { get; }

    public int StatusCode => (int)HttpStatusCode.BadRequest;
}
