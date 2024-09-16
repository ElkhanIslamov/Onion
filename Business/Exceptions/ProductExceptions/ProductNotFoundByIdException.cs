using System.Net;

namespace Business.Exceptions.ProductExceptions;

public sealed class ProductNotFoundByIdException:Exception,IBaseException
{
    public ProductNotFoundByIdException(string message):base(message)
    {
        ErrorMessage = message;
    }

	public string ErrorMessage { get; }

	public int StatusCode => (int)HttpStatusCode.NotFound;
}
