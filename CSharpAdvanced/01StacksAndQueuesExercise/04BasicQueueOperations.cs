using System;
using System.Collections.Generic;
using System.Linq;

namespace _04BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int enqueueN = commands[0];
            int dequeueS = commands[1];
            int containsX = commands[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < Math.Min(enqueueN, numbers.Length); i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < dequeueS; i++)
            {
                if (queue.Count == 0)
                {
                    break;
                }

                queue.Dequeue();
            }

            if (queue.Contains(containsX))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
