
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Business.Exceptions.UserExceptions;

public sealed class CreateFailedException : Exception, IBaseException
{
    public CreateFailedException(IEnumerable<IdentityError> errors)
    {
        ErrorMessage = string.Join(" ", errors.Select(errors=>errors.Description));
    }
    public string ErrorMessage { get;}

	public int StatusCode => (int)HttpStatusCode.Unauthorized;
}
