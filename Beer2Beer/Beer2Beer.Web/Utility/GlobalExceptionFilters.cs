using Beer2Beer.Services.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Beer2Beer.Web.Utility
{
    public class GlobalExceptionFilters : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(!context.ExceptionHandled)
            {
                var exception = context.Exception;
                int statusCode = 0;

                switch (true)
                {
                    case bool _ when exception is InvalidUserInputException:
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                }

                context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
            }
        }
    }
}
