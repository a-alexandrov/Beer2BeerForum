using System;

namespace Beer2Beer.Services.CustomExceptions
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException(string message)
            : base(message)
        {
        }

        public InvalidUserInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
