using System;

namespace _04HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hotelInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            decimal pricePerDay = decimal.Parse(hotelInfo[0]);
            int daysNumber = int.Parse(hotelInfo[1]);
            Season season = (Season)Enum.Parse(typeof(Season), hotelInfo[2]);
            Discount discount = (Discount)Enum.Parse(typeof(Discount), "None"); 
            if (hotelInfo.Length == 4)
            {
                discount = (Discount)Enum.Parse(typeof(Discount), hotelInfo[3]);
            }
            
            decimal calculatedPrice = ClculatePrice(pricePerDay, daysNumber, season, discount);
            Console.WriteLine("{0:f2}", calculatedPrice);
        }

        private static decimal ClculatePrice(decimal pricePerDay, int daysCount, Season season, Discount discount)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;
            decimal priceBeforeDiscount = pricePerDay * daysCount * multiplier;
            decimal discountedAmount = priceBeforeDiscount * discountMultiplier;
            decimal finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;
        }
    }
}