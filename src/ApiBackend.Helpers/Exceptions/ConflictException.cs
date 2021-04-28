using System;

namespace ApiBackend.Helpers.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public ConflictException(string message) : base(message)
        {
            
        }  
    }
}