using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Core;
using WinterIsComingMain.Interfaces;

namespace WinterIsComingMain
{
    public class WinterIsComingMain
    {
        private const int MatrixRows = 5;
        private const int MatrixCols = 5;

        static void Main()
        {
            IInputReader consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter
            {
                AutoFlush = true
            };

            IUnitContainer unitMatrix = new MatrixContainer(MatrixRows, MatrixCols);
            ICommandDispatcher commandDispatcher = new CommandDispatcher();
            IUnitEffector unitEffector = new HealthUnitEffector();

            var engine = new Engine(unitMatrix,
                consoleReader,
                consoleWriter,
                commandDispatcher,
                unitEffector);

            engine.Start();
        }
    }
}