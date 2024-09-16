using System.Net;

namespace Business.Exceptions.CategoryExceptions;

public	sealed class CategoryAlreadyExistException:Exception, IBaseException
{
    public CategoryAlreadyExistException(string message):base(message)
    {
        ErrorMessage = message;
    }

	public string ErrorMessage { get; }

	public int StatusCode => (int)HttpStatusCode.Conflict;
}
