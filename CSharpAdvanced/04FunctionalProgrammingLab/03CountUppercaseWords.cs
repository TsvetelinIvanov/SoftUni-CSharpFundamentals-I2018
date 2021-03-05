using System;
using System.Linq;

namespace _03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];           
            words.Where(checker).ToList().ForEach(n => Console.WriteLine(n));
        }
    }
}
