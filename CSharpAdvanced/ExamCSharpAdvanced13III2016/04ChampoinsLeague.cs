using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ChampoinsLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> teemsScores = new Dictionary<string, int>();
            Dictionary<string, List<string>> teemsOpponents = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                string[] matchData = input.Split(new string[] { " | " }, StringSplitOptions.None);
                string firstTeam = matchData[0];
                string secondTeam = matchData[1];
                int firstGoalsHome = int.Parse(matchData[2].Split(':').First());
                int secondGoalsHome = int.Parse(matchData[3].Split(':').First());
                int firstGoalsGuest = int.Parse(matchData[3].Split(':').Last());
                int secondGoalsGuest = int.Parse(matchData[2].Split(':').Last());                

                if (!teemsScores.ContainsKey(firstTeam))
                {
                    teemsScores[firstTeam] = 0;
                    teemsOpponents[firstTeam] = new List<string>();
                }

                if (!teemsScores.ContainsKey(secondTeam))
                {
                    teemsScores[secondTeam] = 0;
                    teemsOpponents[secondTeam] = new List<string>();
                }

                teemsOpponents[firstTeam].Add(secondTeam);
                teemsOpponents[secondTeam].Add(firstTeam);

                if (firstGoalsHome + firstGoalsGuest > secondGoalsHome + secondGoalsGuest)
                {
                    teemsScores[firstTeam]++;
                }
                else if (firstGoalsHome + firstGoalsGuest < secondGoalsHome + secondGoalsGuest)
                {
                    teemsScores[secondTeam]++;
                }
                else
                {
                    if (firstGoalsGuest > secondGoalsGuest)
                    {
                        teemsScores[firstTeam]++;
                    }
                    else if (firstGoalsGuest < secondGoalsGuest)
                    {
                        teemsScores[secondTeam]++;
                    }
                    else
                    {
                        Console.WriteLine("This is not real!");
                    }
                }
            }

            foreach (KeyValuePair<string, int> teem in teemsScores.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine(teem.Key);
                Console.WriteLine("- Wins: " + teem.Value);
                Console.WriteLine("- Opponents: " + string.Join(", ", teemsOpponents[teem.Key].OrderBy(o => o)));
            }
        }
    }
}
