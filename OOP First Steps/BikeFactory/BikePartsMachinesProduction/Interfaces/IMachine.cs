using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Interfaces
{
    using Enum;

    public interface IMachine : IFrameProducer
    {
        MachineType MachineType { get; }
    }
}
