using System;
using System.Collections.Generic;

namespace _05CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            Queue<long> queueCurrentS = new Queue<long>();
            queueCurrentS.Enqueue(n);
            queue.Enqueue(n);

            for (int i = 0; i < 17; i++)
            {
                long s1 = queueCurrentS.Dequeue();
                long s2 = s1 + 1;
                queue.Enqueue(s2);
                queueCurrentS.Enqueue(s2);
                long s3 = 2 * s1 + 1;
                queue.Enqueue(s3);
                queueCurrentS.Enqueue(s3);
                long s4 = s1 + 2;
                queue.Enqueue(s4);
                queueCurrentS.Enqueue(s4);
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(queue.Dequeue() + " ");
            }

            Console.WriteLine();
        }
    }
}
