namespace Business.Exceptions;

public  interface IBaseException
{
	string ErrorMessage { get; }
	int StatusCode {  get; }

}
