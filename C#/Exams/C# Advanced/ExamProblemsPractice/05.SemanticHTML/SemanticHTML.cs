using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.SemanticHTML
{
    class SemanticHTML
    {
        static void Main()
        {
            string divClassPattern = @"<div.+?(class\s*=\s*""(main|header|nav|article|section|aside|footer)""\s*).*>";
            string divIdPattern = @"<div.+?(id\s*=\s*""(main|header|nav|article|section|aside|footer)""\s*).*>";
            Regex regex = new Regex(divClassPattern);
            MatchCollection matches = regex.Matches("");
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                regex = new Regex(divClassPattern);
                matches = regex.Matches(line);
                if (matches.Count > 0)
                {
                    foreach (var match in matches)
                    {
                            string replace = match
                    }
                }
            }
        }
    }
}
