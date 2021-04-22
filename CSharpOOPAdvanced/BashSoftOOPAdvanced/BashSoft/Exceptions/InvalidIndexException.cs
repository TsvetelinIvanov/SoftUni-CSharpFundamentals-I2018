using System;

namespace BashSoft.Exceptions
{
    public class InvalidIndexException : Exception
    {
        private const string InvalidIndexExceptionMessage = "Invalid index: {0}!";

        public InvalidIndexException(string message) : base(message)
        {

        }

        public InvalidIndexException(int invalidIndex) : base(string.Format(InvalidIndexExceptionMessage, invalidIndex))
        {

        }
    }
}