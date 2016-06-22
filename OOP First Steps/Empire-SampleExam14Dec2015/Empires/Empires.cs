using Empires.Core;
using Empires.Core.Factories;
using Empires.IO;

namespace Empires
{
    public class Empires
    {
        static void Main()
        {
            var buildingFactory = new BuildingFactory();
            var resourceFactory = new ResourceFactory();
            var unitFactory = new UnitFactory();
            var data = new Data();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(
                buildingFactory,
                resourceFactory,
                unitFactory,
                data,
                reader,
                writer);

            engine.Run();
        }
    }
}
