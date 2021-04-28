using System;

namespace ApiBackend.Helpers.Exceptions
{
    public class InvalidException : ApplicationException
    {
        public InvalidException(string message) : base(message)
        {
            
        }
    }
}