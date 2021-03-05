using System;

namespace _10HeiganDance
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] chamber = new int[15, 15];
            int[] playerPosition = new int[] { 7, 7 };
            int playerHealth = 18500;
            double heiganHealth = 3000000;
            bool isPlagueCloudAfected = false;
            bool isKilledByPlagueCloud = false;
            bool isKilledByEruption = false;
            bool isHeiganDefeated = false;
            double playerDamage = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (true)
            {
                string[] spellParameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                heiganHealth -= playerDamage;
                if (heiganHealth <= 0)
                {
                    isHeiganDefeated = true;
                }

                if (isPlagueCloudAfected)
                {
                    playerHealth -= 3500;
                    isPlagueCloudAfected = false;

                    if (playerHealth <= 0)
                    {
                        isKilledByPlagueCloud = true;
                    }
                }                

                if (isHeiganDefeated || isKilledByPlagueCloud)
                {
                    break;
                }

                string spell = spellParameters[0];
                int damageRow = int.Parse(spellParameters[1]);
                int damageCol = int.Parse(spellParameters[2]);

                if (IsPlayerAffcted(playerPosition[0], playerPosition[1] , damageRow, damageCol))
                {
                    int playerOldRow = playerPosition[0];
                    int playerOldCol = playerPosition[1];
                    playerPosition = TryToMove(chamber, playerPosition, damageRow, damageCol);
                    if (playerOldRow == playerPosition[0] && playerOldCol == playerPosition[1])
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerHealth -= 3500;
                                isPlagueCloudAfected = true;
                                if (playerHealth <= 0)
                                {
                                    isKilledByPlagueCloud = true;
                                }

                                break;
                            case "Eruption":
                                playerHealth -= 6000;                                
                                if (playerHealth <= 0)
                                {
                                    isKilledByEruption = true;
                                }

                                break;
                        }
                    }
                }

                if (isKilledByEruption || isKilledByPlagueCloud)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (isHeiganDefeated)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine("Heigan: {0:f2}", heiganHealth);
            }

            if (isKilledByPlagueCloud)
            {
                Console.WriteLine("Player: Killed by Plague Cloud");
            }
            else if (isKilledByEruption)
            {
                Console.WriteLine("Player: Killed by Eruption");
            }
            else
            {
                Console.WriteLine("Player: " + playerHealth);
            }

            Console.WriteLine("Final position: " + playerPosition[0] + ", " + playerPosition[1]);
        }

        private static bool IsPlayerAffcted(int playerRow, int playerCol, int damageRow, int damageCol)
        {
            bool isPlayerAffctedRow = playerRow == damageRow || playerRow == damageRow - 1 || playerRow == damageRow + 1;
            bool isPlayerAffctedCol = playerCol == damageCol || playerCol == damageCol - 1 || playerCol == damageCol + 1;
            bool isPlayerAffcted = isPlayerAffctedRow && isPlayerAffctedCol;

            return isPlayerAffcted;
        }

        private static int[] TryToMove(int[,] chamber, int[] playerPosition, int damageRow, int damageCol)
        {            
            if (IsInChamber(chamber, playerPosition[0] - 1, playerPosition[1]) && 
                !IsPlayerAffcted(playerPosition[0] - 1, playerPosition[1], damageRow, damageCol))
            {
                playerPosition[0]--;
            }
            else if (IsInChamber(chamber, playerPosition[0], playerPosition[1] + 1) &&
                !IsPlayerAffcted(playerPosition[0], playerPosition[1] + 1, damageRow, damageCol))
            {
                playerPosition[1]++;
            }
            else if (IsInChamber(chamber, playerPosition[0] + 1, playerPosition[1]) &&
                !IsPlayerAffcted(playerPosition[0] + 1, playerPosition[1], damageRow, damageCol))
            {
                playerPosition[0]++;
            }
            else if (IsInChamber(chamber, playerPosition[0], playerPosition[1] - 1) &&
                !IsPlayerAffcted(playerPosition[0], playerPosition[1]  - 1, damageRow, damageCol))
            {
                playerPosition[1]--;
            }

            return playerPosition;
        }

        private static bool IsInChamber(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }        
    }
}
