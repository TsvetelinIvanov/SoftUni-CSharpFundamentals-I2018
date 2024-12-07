using System;

namespace BashSoft.Exceptions
{
    public class UnableToParseNumberException : Exception
    {
        private const string UnableToParseNumberExceptionMessage = "The sequence you have written is not a valid number!";

        public UnableToParseNumberException() : base(UnableToParseNumberExceptionMessage)
        {

        }

        public UnableToParseNumberException(string message) : base(message)
        {

        }
    }
}
