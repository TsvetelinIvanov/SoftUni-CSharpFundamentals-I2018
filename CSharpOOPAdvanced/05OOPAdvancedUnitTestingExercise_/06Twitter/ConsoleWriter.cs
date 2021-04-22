using _06Twitter.Contracts;
using System;

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