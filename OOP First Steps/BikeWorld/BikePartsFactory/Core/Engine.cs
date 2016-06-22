using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsFactory.Interfaces;
using BikePartsFactory.PartProductionProceses;
using BikePartsFactory.IO;
using BikePartsFactory.Menus;

namespace BikePartsFactory.Core
{
    public class Engine : IEngine
    {
        private IFrameProductionManager frameProductionManager;
        private IFactoryData factoryData;
        private IFrameFactory frameFactory;
        private IFrameMenuCommandExecute frameMenuCommand;
        private IMenu menu;
        private IConsoleReader reader;
        private IConsoleClear clear;
        private IConsoleWriter writer;

        public Engine(
            IFrameProductionManager frameProductionManager,
            IFactoryData factoryData,
            IFrameFactory frameFactory,
            IFrameMenuCommandExecute frameMenuCommand,
            IMenu menu,
            IConsoleReader reader,
            IConsoleClear clear,
            IConsoleWriter writer
            )
        {
            this.frameProductionManager = frameProductionManager;
            this.factoryData = factoryData;
            this.frameFactory = frameFactory;
            this.frameMenuCommand = frameMenuCommand;
            this.menu = menu;
            this.reader = reader;
            this.clear = clear;
            this.writer = writer;
        }

        public void Run()
        {
            ExecuteCommands();
        }

        private void ExecuteCommands()
        {
            writer.WriteLine(menu.PrintStartingMenu());
            string input = reader.ReadLine();
            clear.Clear();

            switch (input)
            {
                case "1":
                    View();
                    break;
                case "2":
                    this.frameMenuCommand.ExecuteSelectFrameTypeMenu(this.reader, this.writer, this.clear, this.menu, this);
                    ExecuteFrameProductionProces(frameMenuCommand.FrameSpecification);
                    break;
                default:
                    break;
            }
        }

        private void View()
        {
            clear.Clear();
            if (frameMenuCommand.FrameSpecification != null)
            {
                foreach (var item in this.factoryData.PartsList)
                {
                    Console.WriteLine(item.ModelNumber);
                }
            }
            else
            {
                Console.WriteLine("NOOOOOOOOOOOOOOOOOO ;((((");
            }
        }

        private void ExecuteFrameProductionProces(IList<string> frameSpecification)
        {
            var frameProductionProces = frameProductionManager.StartProces(
             frameSpecification[0],
             Convert.ToDouble(frameSpecification[1]),
             Convert.ToDouble(frameSpecification[2]),
             frameSpecification[3],
             this.frameFactory);

            var frame = frameProductionProces.ProducePart();
            factoryData.AddPartToList(frame);
            this.Run();

        }
    }
}
