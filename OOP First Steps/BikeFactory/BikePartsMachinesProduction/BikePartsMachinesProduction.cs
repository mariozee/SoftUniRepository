using BikePartsMachinesProduction.Factory;
using BikePartsMachinesProduction.IO;
using BikePartsMachinesProduction.BikeFactoryData;
using BikePartsMachinesProduction.Core.Engine;
using BikePartsMachinesProduction.Core;

namespace BikePartsMachinesProduction
{
    class BikePartsMachinesProduction
    {
        static void Main()
        {
            var partFactory = new PartFactory();
            var machineFactory = new MachineFactory();
            var bikeFactoryData = new BikeFactoryData.BikeFactoryData();
            var menu = new Menu();
            var reader = new Reader();
            var writer = new Writer();

            var engine = new Engine(machineFactory, bikeFactoryData, menu, reader, writer);

            engine.Run();

        }
    }
}
