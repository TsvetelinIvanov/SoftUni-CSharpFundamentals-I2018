using System;

namespace BashSoft.Exceptions
{
    public class InvalidTakeQantityParameterException : Exception
    {
        private const string InvalidTakeQantityParameterExceptionMessage = "The take command expected does not match the format wanted!";

        public InvalidTakeQantityParameterException() : base(InvalidTakeQantityParameterExceptionMessage)
        {

        }

        public InvalidTakeQantityParameterException(string message) : base(message)
        {

        }
    }
}