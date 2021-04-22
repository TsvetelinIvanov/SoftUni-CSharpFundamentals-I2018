using System;
using System.Globalization;

namespace _09DateTimeNowAddDays
{
    class Program
    {
        private static DateTime DateTimeNow = DateTime.Parse("04/09/2018",
                CultureInfo.InvariantCulture);

        static void Main(string[] args)
        {
            DateTime leapYear = DateTime.Parse("02/28/2020", CultureInfo.InvariantCulture);
            DateTime nonLeapYear = DateTime.Parse("02/28/2018", CultureInfo.InvariantCulture);

            DateTime minValue = DateTime.MinValue;
            Console.WriteLine(minValue);

            DateTime maxValue = DateTime.MaxValue;
            Console.WriteLine(maxValue);

            string expectedDateToTheMiddleofMonth = DateTimeNow.AddDays(11).Date.ToString();
            Console.WriteLine(expectedDateToTheMiddleofMonth);

            string expectedDateToToTheEndOfMonth = DateTimeNow.AddDays(20).Date.ToString();
            Console.WriteLine(expectedDateToToTheEndOfMonth);

            string expectedDateToTheNextMonth = DateTimeNow.AddDays(26).Date.ToString();
            Console.WriteLine(expectedDateToTheNextMonth);

            string expectedDateToThePreviousMonth = DateTimeNow.AddDays(-15).Date.ToString();
            Console.WriteLine(expectedDateToThePreviousMonth);

            string expectedDateToLeapYear = leapYear.AddDays(1).Date.ToString();
            Console.WriteLine(expectedDateToLeapYear);

            string expectedDateToNonLeapYear = nonLeapYear.AddDays(1).Date.ToString();
            Console.WriteLine(expectedDateToNonLeapYear);

            string expectedDateToMinValue = minValue.AddDays(1).Date.ToString();
            Console.WriteLine(expectedDateToMinValue);

            string expectedDateToMaxValue = maxValue.AddDays(-1).Date.ToString();
            Console.WriteLine(expectedDateToMaxValue);
        }
    }
}