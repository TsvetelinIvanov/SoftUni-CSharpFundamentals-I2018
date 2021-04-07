using System;

namespace BashSoft.Exceptions
{
    public class InvalidStringException : Exception
    {
        private const string NullOrEmptyValueExceptionMessage = "The value of the variable cannot be null or empty!";

        public InvalidStringException() : base(NullOrEmptyValueExceptionMessage)
        {

        }

        public InvalidStringException(string message) : base(message)
        {

        }
    }
}