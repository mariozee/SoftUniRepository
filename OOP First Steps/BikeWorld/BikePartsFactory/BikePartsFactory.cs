using BikePartsFactory.Core;
using BikePartsFactory.Core.Factory;
using BikePartsFactory.Core.ProductionManager;
using BikePartsFactory.Interfaces;
using BikePartsFactory.IO;
using BikePartsFactory.Menus;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory
{
    public class BikePartsFactory
    {
        static void Main()
        {
            FrameProductionManager frameProdusctionManager = new FrameProductionManager();
            FactoryData factoryData = new FactoryData();
            FrameFactory frameFactory = new FrameFactory();
            FrameMenuCommandExecute frameMenuCommand = new FrameMenuCommandExecute();
            Menu menu = new Menu();
            ConsoleReader reader = new ConsoleReader();
            ConsoleClear clear = new ConsoleClear();
            ConsoleWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(
                frameProdusctionManager, 
                factoryData, 
                frameFactory, 
                frameMenuCommand, 
                menu, 
                reader, 
                clear, 
                writer);

            engine.Run();

        }
    }
}
