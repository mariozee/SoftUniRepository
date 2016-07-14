using _05.PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PizzaCalories
{
    public class Startup
    {
        public static void Main()
        {
            try
            {
                string command = Console.ReadLine();
                while (command != "END")
                {
                    if (command.Split()[0] == "Pizza")
                    {                       
                        string pizzaName = command.Split()[1];
                        int toppingCount = int.Parse(command.Split()[2]);
                        var pizza = new Pizza(pizzaName, toppingCount);

                        string line = Console.ReadLine();
                        string doughType = line.Split()[1];
                        string bakingTechnique = line.Split()[2];
                        double doughtWeight = double.Parse(line.Split()[3]);
                        var dough = new Dough(doughType, bakingTechnique, doughtWeight);

                        pizza.Dough = dough;

                        for (int i = 0; i < toppingCount; i++)
                        {
                            line = Console.ReadLine();
                            string toppingType = line.Split()[1];
                            double toppingWeight = double.Parse(line.Split()[2]);
                            var topping = new Topping(toppingType, toppingWeight);

                            pizza.AddToppin(topping);
                        }

                        Console.WriteLine("{0} - {1:F2} Calories", pizza.Name, pizza.Calories);
                    }
                    else if (command.Split()[0] == "Dough")
                    {
                        string doughtType = command.Split()[1];
                        string bakingTechnique = command.Split()[2];
                        double weight = double.Parse(command.Split()[3]);
                        var dough = new Dough(doughtType, bakingTechnique, weight);

                        Console.WriteLine("{0:F2}", dough.Calories);
                    }
                    else if (command.Split()[0] == "Topping")
                    {
                        string toppingType = command.Split()[1];
                        double weight = double.Parse(command.Split()[2]);
                        var topping = new Topping(toppingType, weight);

                        Console.WriteLine("{0:F2}", topping.Calories);
                    }                

                    command = Console.ReadLine();
                }                
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

           
        }
    }
}
