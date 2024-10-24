using System;
using System.Linq;

namespace _13ThreeFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> filter = (name, num) => name.ToCharArray().Sum(ch => ch) >= num;
            string firstLargeName = names.FirstOrDefault(name => filter(name, number));
            Console.WriteLine(firstLargeName);
        }
    }
}
