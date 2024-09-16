using System.Net;

namespace Business.Exceptions.CategoryExceptions;

public sealed class CategoryNotFoundByIdException:Exception,IBaseException
{
    public CategoryNotFoundByIdException(string message):base(message)
    {
        ErrorMessage = message;
    }

	public string ErrorMessage { get; }

	public int StatusCode => (int)HttpStatusCode.NotFound;
}
