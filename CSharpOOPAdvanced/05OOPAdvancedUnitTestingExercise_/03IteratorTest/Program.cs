using System;
using System.Linq;
using System.Reflection;

namespace _03IteratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputIteratorArgs = Console.ReadLine().Split();
            string[] iteratorArgs = inputIteratorArgs.Skip(1).ToArray();
            ListIterator iterator = new ListIterator(iteratorArgs);

            MethodInfo[] iteratorMethods = iterator.GetType().GetMethods();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    MethodInfo parsedMethod = iteratorMethods.FirstOrDefault(m => m.Name == command);
                    if (parsedMethod == null)
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    string result = parsedMethod.Invoke(iterator, new object[] { }).ToString();
                    Console.WriteLine(result);
                }
                catch (TargetInvocationException tie)
                {
                    if (tie.InnerException is InvalidOperationException iae)
                    {
                        Console.WriteLine(iae.Message);
                        //Console.WriteLine(tie.InnerException.Message);
                    }
                }
                catch (ArgumentNullException)
                {

                }
            }
        }
    }
}
