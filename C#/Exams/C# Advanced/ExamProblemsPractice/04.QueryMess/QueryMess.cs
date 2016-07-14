using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.QueryMess
{
    class QueryMess
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> querys; 
            string line = string.Empty;
            while ((line = Console.ReadLine()) != "END")
            {
                querys = new Dictionary<string, List<string>>();

                //Removes everything on the left of '?' including.
                line = new Regex(@".+[?]").Replace(line, "");
                //Replace '%20' with single space ' '.
                line = new Regex(@"%20").Replace(line, " ");
                //Replace any whitespace assuming that '+' is also whitespace, with single space ' '.
                line = new Regex(@"[+\s]+").Replace(line, " ");

                string[] lineArgs = line.Split('&');

                foreach (var elements in lineArgs)
                {
                    //Splitig keys from values while remove redunded whitespaces.
                    string key = elements.Split('=')[0].Trim();
                    string value = elements.Split('=')[1].Trim();

                    if (!querys.ContainsKey(key))
                    {
                        querys.Add(key, new List<string>());
                    }
                    
                    querys[key].Add(value);
                }

                PrintLine(querys);
            }
        }

        private static void PrintLine(Dictionary<string, List<string>> querys)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pair in querys)
            {
                sb.AppendFormat($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
            }                      

            Console.WriteLine(sb.ToString());
        }
    }
}