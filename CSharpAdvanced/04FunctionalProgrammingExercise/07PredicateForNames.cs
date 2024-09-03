using System;
using System.Linq;

namespace _07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> filter = name => name.Length <= n;
            string[] filteredNames = names.Where(filter).ToArray();
            
            Action<string[]> printer = fn => Console.WriteLine(string.Join(Environment.NewLine, fn)); 
            printer(filteredNames);
        }
    }
}
