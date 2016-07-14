namespace KremenCity
{
    using System;

    public class Startup
    {
        static void Main()
        {
            KermenData data = new KermenData();
            Factory factory = new Factory();
            int commandsCounter = 0;

            string input = Console.ReadLine();
            
            while (true)
            {
                commandsCounter++;
                bool areSalariesPayd = false;

                try
                {
                    if (input == "EVN")
                    {
                        decimal consumption = data.GetTotalConsumption();
                        Console.WriteLine("Total consumption: {0}", consumption);
                    }
                    else if (input == "EVN bill")
                    {
                        if (commandsCounter % 3 == 0)
                        {
                            data.PaySalaries();
                            areSalariesPayd = true;
                        }

                        data.PayBills();
                    }
                    else if (input == "Democracy")
                    {
                        int population = data.GetPopulationCount();
                        Console.WriteLine("Total population: {0}", population);
                        break;
                    }
                    else
                    {
                        var household = factory.CreateHousehold(input);
                        data.AddHousehold(household);
                    }

                    if (commandsCounter % 3 == 0 && !areSalariesPayd)
                    {
                        data.PaySalaries();
                    }
                }
                catch (ArgumentException)
                {
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }            
        }        
    }
}