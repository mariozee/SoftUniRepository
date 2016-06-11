using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class PredicateParty
    {
        static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string input;
            List<string> targets = new List<string>();

            while ((input = Console.ReadLine()) != "Party!")
            {
                string command = input.Split()[0];
                string criteria = input.Split()[1];
                string param = input.Split()[2];

                if (criteria == "StartsWith")
                {
                    targets = GetTargetsNames(names, n => n.StartsWith(param));
                }
                else if (criteria == "EndsWith")
                {
                    targets = GetTargetsNames(names, n => n.EndsWith(param));
                }
                else
                {
                    int lenght = int.Parse(param);
                    targets = GetTargetsNames(names, n => n.Length == lenght);
                }

                if (command == "Remove")
                {
                    names = RemoveNames(names, targets, (x, y) => x == y);
                }
                else
                {
                    names = DoubleNames(names, targets, (x, y) => x == y);                    
                }
            }

            string peoples = string.Join(", ", names) + " are going to the party!";
            string nobody = "Nobody is going to the party!";
            Console.WriteLine(names.Count > 0 ? peoples : nobody);
        }

        private static List<string> DoubleNames(List<string> names, List<string> targetNames, Func<string,string, bool> func)
        {
            List<string> targets = new List<string>();
            targets.AddRange(names);
            foreach (var target in targetNames)
            {
                foreach (var name in names)
                {
                    if (func(name, target))
                    {
                        int index = targets.IndexOf(name);
                        targets.Insert(index, name);
                        break;
                    }
                }
            }
            return targets;
        }

        private static List<string> RemoveNames(List<string> names, List<string> targetNames, Func<string, string, bool> func)
        {
            List<string> removed = new List<string>();
            removed.AddRange(names);
            foreach (var target in targetNames)
            {
                foreach (var name in names)
                {
                    if (func(name, target))
                    {
                        removed.Remove(name);
                        break;
                    }
                }
            }

            return removed;
        }

        private static List<string> GetTargetsNames(List<string> names, Predicate<string> pred)
        {
            List<string> targets = new List<string>();
            foreach (var name in names)
            {
                if (pred(name))
                {
                    targets.Add(name);
                }
            }

            return targets;
        }
    }
}
