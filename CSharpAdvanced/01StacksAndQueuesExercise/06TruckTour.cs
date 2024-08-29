using System;
using System.Collections.Generic;
using System.Linq;

namespace _06TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] pumpData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(pumpData);
            }

            for (int startPump = 0; startPump < n; startPump++)
            {
                int fuel = 0;
                bool hasBeenCircled = true;
                for (int pump = 0; pump < n; pump++)
                {
                    int[] currentPump = queue.Dequeue();
                    int pumpFuel = currentPump[0];
                    int nextPumpDistance = currentPump[1];
                    queue.Enqueue(currentPump);
                    fuel += pumpFuel - nextPumpDistance;
                    if (fuel < 0)
                    {
                        startPump += pump;
                        hasBeenCircled = false;
                        break;
                    }
                }

                if (hasBeenCircled)
                {
                    Console.WriteLine(startPump);
                    
                    Environment.Exit(0);
                }
            }
        }
    }
}
