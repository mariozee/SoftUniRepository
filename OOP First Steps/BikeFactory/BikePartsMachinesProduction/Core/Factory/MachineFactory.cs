using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsMachinesProduction.Enum;
using BikePartsMachinesProduction.Interfaces;
using BikePartsMachinesProduction.Models.Machines;

namespace BikePartsMachinesProduction.Factory
{
    public class MachineFactory : IMachineFactory
    {
        public IMachine CreateMachine(string machineType)
        {
            switch (machineType)
            {
                case "frameMachine":
                    return new FrameMachine();

                default:
                    throw new ArgumentException("Unsupported machine.");
            }
        }
    }
}
