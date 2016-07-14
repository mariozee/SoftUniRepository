namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Startup
    {
        static void Main(string[] args)
        {
            var personsInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var productInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var persons = new HashSet<Person>();
            var products = new HashSet<Product>();

            try
            {
                foreach (var personInfo in personsInput)
                {
                    string name = personInfo.Split('=')[0];
                    double money = double.Parse(personInfo.Split('=')[1]);
                    var person = new Person(name, money);
                    persons.Add(person);
                }

                foreach (var prodctInfo in productInput)
                {
                    string name = prodctInfo.Split('=')[0];
                    double cost = double.Parse(prodctInfo.Split('=')[1]);
                    var product = new Product(name, cost);
                    products.Add(product);
                }

                string line = Console.ReadLine();
                while (line != "END")
                {
                    string personName = line.Split()[0];
                    string productName = line.Split()[1];

                    var currentProduct = products.Where(p => p.Name == productName).FirstOrDefault();
                    var currentPerson = persons.Where(p => p.Name == personName).First();

                    if (currentPerson == null || currentProduct == null)
                    {
                        line = Console.ReadLine();
                        continue;
                    }

                    string message = currentPerson.BuyProduct(currentProduct);
                    Console.WriteLine(message);

                    line = Console.ReadLine();
                }

                foreach (var person in persons)
                {
                    if (person.Products.Count > 0)
                    {
                        Console.WriteLine($"{person.Name} - {String.Join(", ", person.Products.Select(p => p.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }   
        }
    }
}