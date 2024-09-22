using System;
using System.Collections.Generic;
using System.Linq;

namespace _04SrapskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> concerts = new Dictionary<string, Dictionary<string, long>>();
            string concertsData = string.Empty;
            while ((concertsData = Console.ReadLine()) != "End")
            {
                string[] rawConcertsData = concertsData.Split('@');
                if (rawConcertsData[0].EndsWith(" "))
                {
                    string singer = rawConcertsData[0].Trim();

                    string[] venueData = rawConcertsData[1].Split();
                    if (long.TryParse(venueData[venueData.Length - 1], out long ticketsCount)
                        && long.TryParse(venueData[venueData.Length - 2], out long ticketPrice)
                        && venueData.Length >= 3)
                    {                        
                        long ticketsIncom = ticketsCount * ticketPrice;
                        string venue = string.Empty;
                        for (int i = 0; i < venueData.Length - 2; i++)
                        {
                            venue += venueData[i] + " ";
                        }

                        if (!concerts.ContainsKey(venue))
                        {
                            concerts.Add(venue, new Dictionary<string, long>());
                        }

                        if (!concerts[venue].ContainsKey(singer))
                        {
                            concerts[venue][singer] = 0;
                        }

                        concerts[venue][singer] += ticketsIncom;
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, long>> venue in concerts)
            {
                Console.WriteLine(venue.Key);
                foreach (KeyValuePair<string, long> singer in venue.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
