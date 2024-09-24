using System.Net;

namespace Business.Exceptions.FileExceptions;

public class FileSizeException : Exception, IBaseException
{
    public FileSizeException(string message) : base(message)
    {
        ErrorMessage = message;
    }
    public string ErrorMessage { get; }

    public int StatusCode => (int)HttpStatusCode.BadRequest;
}
