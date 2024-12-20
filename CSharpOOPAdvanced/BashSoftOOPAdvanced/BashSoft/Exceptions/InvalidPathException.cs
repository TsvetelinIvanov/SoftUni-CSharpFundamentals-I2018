﻿using System;

namespace BashSoft.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string InvalidPathExceptionMessage = "The source does not exist!";
        
        public InvalidPathException() : base(InvalidPathExceptionMessage)
        {

        }

        public InvalidPathException(string message) : base(message)
        {

        }
    }
}
