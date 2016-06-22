using BikePartsMachinesProduction.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Interfaces
{
    public interface IMachineFactory
    {
        IMachine CreateMachine(string machineType);
    }
}
