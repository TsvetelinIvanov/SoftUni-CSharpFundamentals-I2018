using System;
using System.Collections.Generic;
using System.Linq;

namespace _01KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int usedBullets = 0;
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int gunBarrelCounter = 0;
            int[] bulletsBag = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>();
            for (int i = 0; i < bulletsBag.Length; i++)
            {
                bullets.Push(bulletsBag[i]);
            }

            int [] locksInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(locksInput);
            int intelligenceValue = int.Parse(Console.ReadLine());
            bool isSafeOpened = false;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Pop();
                usedBullets++;               

                int lockN = locks.Peek();
                if (bullet <= lockN)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();

                    if (locks.Count == 0)
                    {
                        isSafeOpened = true;
                    }                    
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                gunBarrelCounter++;
                if (gunBarrelCounter == gunBarrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    gunBarrelCounter = 0;
                }
            }

            int buulletCost = usedBullets * bulletPrice;
            int earnedSum = intelligenceValue - buulletCost;

            if (isSafeOpened)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedSum}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: " + locks.Count);
            }
        }
    }
}
