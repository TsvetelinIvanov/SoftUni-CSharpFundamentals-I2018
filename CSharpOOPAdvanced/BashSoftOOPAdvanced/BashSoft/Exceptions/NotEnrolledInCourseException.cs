using System;

namespace BashSoft.Exceptions
{
    public class NotEnrolledInCourseException : Exception
    {
        private const string NotEnrolledInCourseExceptionMessage = "Student must be enrolled in a course before you set his mark!";

        public NotEnrolledInCourseException() : base(NotEnrolledInCourseExceptionMessage)
        {

        }

        public NotEnrolledInCourseException(string message) : base(message)
        {

        }
    }
}