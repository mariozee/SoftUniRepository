using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicatesForNames
{
    public class PredicatesForNames
    {
        public static void Main()
        {
            int maxNameLenght = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ').ToList();
            names = SelectNames(names, s => s.Length <= maxNameLenght);
            Print(names, n => Console.WriteLine(n));
        }

        private static void Print(List<string> names , Action<string> act)
        {
            foreach (var name in names)
            {
                act(name);
            }
        }

        private static List<string> SelectNames(List<string> names, Predicate<string> pred)
        {
            List<string> selectedNames = new List<string>();
            foreach (var name in names)
            {
                if (pred(name))
                {
                    selectedNames.Add(name);
                }
            }

            return selectedNames;
        }
    }
}