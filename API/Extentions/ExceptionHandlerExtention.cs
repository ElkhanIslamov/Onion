using Business.Exceptions;
using Business.Exceptions.ProductExceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace API.Extentions;

public static class ExceptionHandlerExtention
{
	public static void AddExceptionHandler(this IApplicationBuilder app)
	{
		app.UseExceptionHandler(error => {
			error.Run(async context => {
				var feature = context.Features.Get<IExceptionHandlerFeature>();

				int statusCode = (int)HttpStatusCode.InternalServerError;
				string message = "Unexpected error occurred...";
				//if (feature?.Error is ProductNotFoundByIdException)
				//{
				//	statusCode = (int)HttpStatusCode.NotFound;
				//	message = feature.Error.Message;
				//};
				if(feature?.Error is IBaseException )
				{
					var error = (IBaseException)feature.Error;
					statusCode = error.StatusCode;
					message = error.ErrorMessage;

				}
				var response = new
				{
					StatusCode = statusCode,
					Message = message
				};
				context.Response.StatusCode = statusCode;
				await context.Response.WriteAsJsonAsync(response);
				await context.Response.CompleteAsync();

			});
		});
	}
}
