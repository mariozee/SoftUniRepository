using System;
using System.Collections.Generic;
using System.Linq;

class PCCatalog
{
    static void Main()
    {
        List<Computer> computers = new List<Computer>();

        Component hdd1 = new Component("HDD", 100, "Seagate");
        Component hdd2 = new Component("HDD", 70);
        Component cpu1 = new Component("CPU", 500);
        Component cpu2 = new Component("CPU", 200);
        Component ram = new Component("RAM", 70, "A-Data 4 GB");



        computers.Add(new Computer("Asd", hdd1, cpu1, cpu2, ram, ram));
        computers.Add(new Computer("asd2", cpu2, hdd2, ram));
        computers.Add(new Computer("asd3", cpu2, hdd1, ram));
        var sortedComputers = computers.OrderBy(x => x.Price);

        foreach (var comp in sortedComputers)
        {
            Console.WriteLine(comp);
        }


    }
}

