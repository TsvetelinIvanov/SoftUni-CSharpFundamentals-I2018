using System;

namespace BashSoft.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string InvalidPathExcepionMessage = "The source does not exist!";

        public InvalidPathException() : base(InvalidPathExcepionMessage)
        {

        }

        public InvalidPathException(string message) : base(message)
        {

        }
    }
}
