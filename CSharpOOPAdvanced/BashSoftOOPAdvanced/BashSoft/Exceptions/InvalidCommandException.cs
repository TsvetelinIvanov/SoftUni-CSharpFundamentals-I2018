using System;

namespace BashSoft.Exceptions
{
    public class InvalidCommandException : Exception
    {
        private const string InvalidCommandExceptionMessage = "The command {0} is invalid!";

        //public InvalidCommandException(string message) : base(message)
        //{

        //}

        public InvalidCommandException(string input) : base(string.Format(InvalidCommandExceptionMessage, input))
        {

        }
    }
}