using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();
            Dictionary<string, Predicate<string>> modules = new Dictionary<string, Predicate<string>>();

            string command = Console.ReadLine();
            while (command != "Print")
            {
                string[] commandArgs = Spliterator(command);
                string action = commandArgs[0];
                string type = commandArgs[1];
                string parameter = commandArgs[2];
                string key = commandArgs[3];

                if (action == "Remove")
                {
                    modules.Remove(key);
                }

                if (action == "Add")
                {
                    if (!modules.ContainsKey(key))
                    {
                        Predicate<string> pred = GetPredicate(type, parameter);
                        modules.Add(key, pred);
                    }
                }

                command = Console.ReadLine();
            }

            names = GetFilteredNames(names, modules);
            Console.WriteLine(string.Join(" ", names));
        }

        private static List<string> GetFilteredNames(List<string> names, Dictionary<string, Predicate<string>> modules)
        {
            List<string> filteredNames = new List<string>();
            filteredNames.AddRange(names);            
            foreach (var pred in modules.Values)
            {
                foreach (var name in names)
               {
                    if (pred(name))
                    {
                        filteredNames.Remove(name);
                    }
                }
            }

            return filteredNames;
        }

        private static Predicate<string> GetPredicate(string type, string parameter)
        {
            Predicate<string> pred;
            switch (type)
            {
                case "Starts with":
                    pred = x => x.StartsWith(parameter);
                    break;
                case "Ends with":
                    pred = x => x.EndsWith(parameter);
                    break;
                case "Lenght":
                    pred = x => x.Length == int.Parse(parameter);
                    break;
                case "Contains":
                    pred = x => x.Contains(parameter);
                    break;
                default:
                    pred = null;
                    break;
            }

            return pred;
        }

        private static string[] Spliterator(string command)
        {
            string[] commands = new string[4];
            commands[0] = command.Split()[0];
            commands[1] = command.Split(';')[1];
            commands[2] = command.Split(';')[2];
            commands[3] = commands[1] + commands[2];

            return commands;
        }
    }
}