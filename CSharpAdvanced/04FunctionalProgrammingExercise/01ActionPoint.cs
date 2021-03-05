using System;
using System.Linq;

namespace _01ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> printer = w => Console.WriteLine(w);
            words.ToList().ForEach(w => printer(w));
        }
    }
}
