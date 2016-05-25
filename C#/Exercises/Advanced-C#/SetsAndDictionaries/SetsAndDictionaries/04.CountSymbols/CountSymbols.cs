using System;
using System.Collections.Generic;

namespace _04.CountSymbols
{
    class CountSymbols
    {
        static void Main()
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> charCount = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (!charCount.ContainsKey(text[i]))
                {
                    charCount.Add(ch, 0);
                }

                charCount[ch]++;
            }

            foreach (var pair in charCount)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}