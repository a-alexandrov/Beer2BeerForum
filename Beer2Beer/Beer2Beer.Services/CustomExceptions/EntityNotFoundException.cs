using System;
using System.Collections.Generic;
using System.Text;

namespace Beer2Beer.Services.CustomExceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message)
            : base(message)
        {
        }
    }
}
