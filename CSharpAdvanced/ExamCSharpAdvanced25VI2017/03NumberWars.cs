using System;
using System.Collections.Generic;
using System.Linq;

namespace _03NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> firsPlayerCards = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries));
            Queue<string> secondPlayerCards = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries));
            int turnCount = 0;
            bool gameOver = false;

            while (turnCount < 1000000 && firsPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && !gameOver)
            {
                turnCount++;
                
                string firstCard = firsPlayerCards.Dequeue();
                int firstCardNumber = GetNumber(firstCard);
                
                string secondCard = secondPlayerCards.Dequeue();
                int secondCardNumber = GetNumber(secondCard);

                if (firstCardNumber > secondCardNumber)
                {
                    firsPlayerCards.Enqueue(firstCard);
                    firsPlayerCards.Enqueue(secondCard);
                }
                else if (secondCardNumber > firstCardNumber)
                {
                    secondPlayerCards.Enqueue(secondCard);
                    secondPlayerCards.Enqueue(firstCard);
                }
                else
                {
                    List<string> cardsHand = new List<string>();
                    cardsHand.Add(firstCard);
                    cardsHand.Add(secondCard);
                    while (!gameOver)
                    {
                        if (firsPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int i = 0; i < 3; i++)
                            {
                                string firstHandCard = firsPlayerCards.Dequeue();
                                int firstHandCardNumber = GetCharNumber(firstHandCard);
                                firstSum += firstHandCardNumber;
                                cardsHand.Add(firstHandCard);

                                string secondHandCard = secondPlayerCards.Dequeue();
                                int secondHandCardNumber = GetCharNumber(secondHandCard);
                                secondSum += secondHandCardNumber;
                                cardsHand.Add(secondHandCard);
                            }

                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(firsPlayerCards, cardsHand);
                                break;
                            }
                            else if (firstSum < secondSum)
                            {
                                AddCardsToWinner(secondPlayerCards, cardsHand);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            if (firsPlayerCards.Count > secondPlayerCards.Count)
            {
                Console.WriteLine($"First player wins after {turnCount} turns");
            }
            else if (firsPlayerCards.Count < secondPlayerCards.Count)
            {
                Console.WriteLine($"Second player wins after {turnCount} turns");
            }
            else
            {
                Console.WriteLine($"Draw after {turnCount} turns");
            }
        }

        private static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        private static int GetCharNumber(string card)
        {
            return card[card.Length - 1];
        }

        private static void AddCardsToWinner(Queue<string> playerCards, List<string> cardsHand)
        {
            foreach (string card in cardsHand.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetCharNumber(c)))
            {
                playerCards.Enqueue(card);
            }
        }        
    }
}
