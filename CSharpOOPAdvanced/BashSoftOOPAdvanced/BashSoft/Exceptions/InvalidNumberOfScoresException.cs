using System;

namespace BashSoft.Exceptions
{
    public class InvalidNumberOfScoresException : Exception
    {
        private const string InvalidNumberOfScoresExceptionMessage = "The number of scores for the given course is greater than the possible one!";

        public InvalidNumberOfScoresException(string message) : base(message)
        {

        }
        
        public InvalidNumberOfScoresException() : base(InvalidNumberOfScoresExceptionMessage)
        {

        }
    }
}
