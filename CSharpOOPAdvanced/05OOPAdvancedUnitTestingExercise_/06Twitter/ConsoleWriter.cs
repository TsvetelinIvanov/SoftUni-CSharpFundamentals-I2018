using System;
﻿using _06Twitter.Contracts;

namespace _06Twitter
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
