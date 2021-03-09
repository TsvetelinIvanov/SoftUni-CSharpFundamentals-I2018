using System;
using System.Linq;

namespace _02CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int maxSequenceLength = 0;
            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step) % numbers.Length;
                    int currentSequenceLength = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currentSequenceLength++;
                    }

                    if (currentSequenceLength > maxSequenceLength)
                    {
                        maxSequenceLength = currentSequenceLength;
                    }
                }
            }

            Console.WriteLine(maxSequenceLength);
        }
    }
}
