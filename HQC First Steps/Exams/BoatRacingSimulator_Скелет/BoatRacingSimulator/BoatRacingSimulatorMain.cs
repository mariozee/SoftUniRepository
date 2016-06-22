using System;
using System.Collections.Generic;
using System.Linq;

namespace BoatRacingSimulator
{
    using BoatRacingSimulator.Core;

    public class BoatRacingSimulatorMain
    {
        public static void Main()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
