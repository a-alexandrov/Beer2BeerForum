using Beer2Beer.Services.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

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
                var message = exception.Message;

                switch (true)
                {
                    case bool _ when exception is InvalidUserInputException:
                        statusCode = StatusCodes.Status400BadRequest;
                        break;
                    case bool _ when exception is EntityNotFoundException:
                        statusCode = StatusCodes.Status404NotFound;
                        break;
                    case bool _ when exception is InvalidActionException:
                        statusCode = StatusCodes.Status403Forbidden;
                        break;
                    case bool _ when exception is DbUpdateException:
                        statusCode = StatusCodes.Status400BadRequest;
                        message = exception.InnerException.ToString(); ///Kalata: needed inner exception body to fix bug
                        break;
                }

                context.Result = new ObjectResult(message) { StatusCode = statusCode };
            }
        }
    }
}
