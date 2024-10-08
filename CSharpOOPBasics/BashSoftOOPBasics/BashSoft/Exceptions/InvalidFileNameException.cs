using System;

namespace BashSoft.Exceptions
{
    public class InvalidFileNameException : Exception
    {
        private const string ForbiddenSymbolsContainedInNameExcepionMessage = "The given name contains symbols that are not allowed to be used in names of files and folders!";

        public InvalidFileNameException() : base(ForbiddenSymbolsContainedInNameExcepionMessage)
        {

        }

        public InvalidFileNameException(string message) : base(message)
        {

        }
    }
}
