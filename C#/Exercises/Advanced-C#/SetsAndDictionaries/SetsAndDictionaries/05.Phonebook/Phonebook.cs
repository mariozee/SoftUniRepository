using System;
using System.Collections.Generic;

namespace _05.Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "search")
            {
                string name = input.Split('-')[0];
                string number = input.Split('-')[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, number);
                }
                else
                {
                    phonebook[name] = number;
                }
           }

            while ((input = Console.ReadLine()) != "stop")
            {
                string name = input;

                if (phonebook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phonebook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
            } 
        }
    }
}