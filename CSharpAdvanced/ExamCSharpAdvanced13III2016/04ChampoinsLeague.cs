using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ChampoinsLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> teamsScores = new Dictionary<string, int>();
            Dictionary<string, List<string>> teamsOpponents = new Dictionary<string, List<string>>();
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

                if (!teamsScores.ContainsKey(firstTeam))
                {
                    teamsScores[firstTeam] = 0;
                    teamsOpponents[firstTeam] = new List<string>();
                }

                if (!teamsScores.ContainsKey(secondTeam))
                {
                    teamsScores[secondTeam] = 0;
                    teamsOpponents[secondTeam] = new List<string>();
                }

                teamsOpponents[firstTeam].Add(secondTeam);
                teamsOpponents[secondTeam].Add(firstTeam);

                if (firstGoalsHome + firstGoalsGuest > secondGoalsHome + secondGoalsGuest)
                {
                    teamsScores[firstTeam]++;
                }
                else if (firstGoalsHome + firstGoalsGuest < secondGoalsHome + secondGoalsGuest)
                {
                    teamsScores[secondTeam]++;
                }
                else
                {
                    if (firstGoalsGuest > secondGoalsGuest)
                    {
                        teamsScores[firstTeam]++;
                    }
                    else if (firstGoalsGuest < secondGoalsGuest)
                    {
                        teamsScores[secondTeam]++;
                    }
                    else
                    {
                        Console.WriteLine("This is not real!");
                    }
                }
            }

            foreach (KeyValuePair<string, int> team in teamsScores.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine(team.Key);
                Console.WriteLine("- Wins: " + team.Value);
                Console.WriteLine("- Opponents: " + string.Join(", ", teamsOpponents[team.Key].OrderBy(o => o)));
            }
        }
    }
}
