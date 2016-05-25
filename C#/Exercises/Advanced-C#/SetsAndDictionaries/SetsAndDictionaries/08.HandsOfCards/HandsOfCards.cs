using System;
using System.Collections.Generic;

namespace _08.HandsOfCards
{
    class HandsOfCards
    {
        static Dictionary<char, int> facePower;
        static Dictionary<char, int> suitPower;

        static void Main()
        {
            facePower = new Dictionary<char, int>()
            {
                { 'J', 11 },
                { 'Q', 12 },
                { 'K', 13 },
                { 'A', 14 }
            };

            suitPower = new Dictionary<char, int>()
            {
                { 'C', 1 },
                { 'D', 2 },
                { 'H', 3 },
                { 'S', 4 }
            };

            Dictionary<string, HashSet<string>> playersHands = new Dictionary<string, HashSet<string>>();

            string input;
            while ((input = Console.ReadLine()) != "JOKER")
            {
                string name = input.Split(':')[0];
                string[] cards = input
                    .Split(':')[1]
                    .Trim()
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!playersHands.ContainsKey(name))
                {
                    playersHands.Add(name, new HashSet<string>());
                }

                foreach (var card in cards)
                {
                    playersHands[name].Add(card);
                }
            }

            foreach (var playerName in playersHands.Keys)
            {
                string name = playerName;
                int score = CalculateScore(playersHands[name]);

                Console.WriteLine($"{name}: {score}");
            }
        }

        private static int CalculateScore(HashSet<string> cards)
        {
            int score = 0;
            int face = 0;
            int suit = 0;
            foreach (var card in cards)
            {
                if (facePower.ContainsKey(card[0]))
                {
                    face = facePower[card[0]];                    
                }
                else
                {
                    string cardFace = card.Substring(0, card.Length - 1);
                    face = int.Parse(cardFace);                    
                }

                suit = suitPower[card[card.Length - 1]];
                score += (face * suit);
            }

            return score;
        }
    }
}