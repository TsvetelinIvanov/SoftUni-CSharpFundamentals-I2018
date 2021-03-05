using System;
using System.IO;

namespace _01OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../Resources/text.txt"))
            {
                int lineNumber = 0;
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;
                }
            }
        }
    }
}
