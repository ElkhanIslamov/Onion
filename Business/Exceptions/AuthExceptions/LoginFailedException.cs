using System.Net;

namespace Business.Exceptions.AuthExceptions;

public class LoginFailedException : Exception, IBaseException
{
    public LoginFailedException(string message) : base(message)
    {
        ErrorMessage = message;
    }
    public string ErrorMessage { get; }
	public int StatusCode => (int)HttpStatusCode.Unauthorized;
}
