using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SO.Integration.API.Domain.Exceptions;

namespace SO.Integration.API.Filters;

public class ExceptionFilter(ILogger<ExceptionFilter> logger) : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		switch (context.Exception)
		{
			case DeserializeFailureException deserializeFailureException:
				logger.LogError(deserializeFailureException, deserializeFailureException.Message);
				var error = new ErrorModel(StatusCodes.Status400BadRequest, deserializeFailureException.Message);
				context.Result = new BadRequestObjectResult(error);
				context.ExceptionHandled = true;
				break;
			default:
				logger.LogError(context.Exception, "An unhandled exception occurred");
				var defaultError = new ErrorModel(StatusCodes.Status500InternalServerError,
					"An unhandled error occurred",
					context.Exception.ToString());
				context.Result = new JsonResult(defaultError);
				context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
				context.ExceptionHandled = true;
				break;
		}
	}
}