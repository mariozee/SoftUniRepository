using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.ExctractHyperlinks
{
    class ExctractHyperlinks
    {
        static void Main(string[] args)
        {
            string inputLine;
            StringBuilder sb = new StringBuilder();
            while (!((inputLine = Console.ReadLine()) == "END"))
            {
                sb.Append(inputLine);
            }
            string text = sb.ToString();

            string pattern = @"<\s*a[^>]*\s+href\s*=\s*(""(.*?)""|'(.*?)'|([^ \n>]*))[\s\S]*?>[\s\S]*?<\s*\/a\s*>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match hyperlink in matches)
            {
                for (int i = 2; i <= 4; i++)
                {
                    if (hyperlink.Groups[i].Length > 0)
                    {
                        Console.WriteLine(hyperlink.Groups[i]);
                    }
                }
            }
        }
    }
}
