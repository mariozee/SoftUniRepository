using System;
using System.Collections.Generic;

namespace _07.FixEmails
{
    class FixEmails
    {
        static void Main()
        {
            Dictionary<string, string> personEmail = new Dictionary<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                string name = input;
                string email = Console.ReadLine();

                string domain = ExtractDomain(email);
                
                if (domain.ToLower() != "us" && domain.ToLower() != "uk")
                {
                    if (!personEmail.ContainsKey(name))
                    {
                        personEmail.Add(name, email);
                    }
                }
            }

            foreach (var pair in personEmail)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static string ExtractDomain(string email)
        {
            string[] separatedEmail = email.Split('.');
            string domain = separatedEmail[separatedEmail.Length - 1];

            return domain;
        }
    }
}