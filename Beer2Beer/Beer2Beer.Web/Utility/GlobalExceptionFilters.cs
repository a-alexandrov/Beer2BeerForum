﻿using Beer2Beer.Services.CustomExceptions;
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
                    case bool _ when exception is DbUpdateException:
                        statusCode = StatusCodes.Status400BadRequest;
                        message = "Invalid input data.";
                        break;
                }

                context.Result = new ObjectResult(message) { StatusCode = statusCode };
            }
        }
    }
}