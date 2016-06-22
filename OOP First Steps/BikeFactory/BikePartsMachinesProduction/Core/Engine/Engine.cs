using BikePartsMachinesProduction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Core.Engine
{
    public class Engine : IEngine
    {
        private IMachineFactory machineFactory;
        private IBikeFactoryData bikeFactoryData;
        private IMenu menu;
        private IReader reader;
        private IWriter writer;

        public Engine(
            IMachineFactory machineFactory,
            IBikeFactoryData bikeFactoryData,
            IMenu menu,
            IReader reader,
            IWriter writer)
        {
            this.machineFactory = machineFactory;
            this.bikeFactoryData = bikeFactoryData;
            this.menu = menu;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            Console.WriteLine(menu.PrintStartingMenu());
            ConsoleKeyInfo asd = Console.ReadKey(true);
            Console.Clear();

            switch (asd.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("its worked");
                    break;
                default:
                    break;
            }
        }
    }
}
