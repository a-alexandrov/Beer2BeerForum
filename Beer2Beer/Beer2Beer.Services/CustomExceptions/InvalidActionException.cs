using System;
using System.Collections.Generic;
using System.Text;

namespace Beer2Beer.Services.CustomExceptions
{
    public class InvalidActionException:Exception
    {
        public InvalidActionException(string message)
            : base(message)
        {
        }

        public InvalidActionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
