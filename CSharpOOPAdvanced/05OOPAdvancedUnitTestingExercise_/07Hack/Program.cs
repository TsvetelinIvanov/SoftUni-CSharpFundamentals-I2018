using System;

namespace _07Hack
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal zero = GetMatAbsZero();
        }

        public static decimal GetMatAbsZero()
        {
            decimal zero = 0m;
            return Math.Abs(zero);
        }
    }
}