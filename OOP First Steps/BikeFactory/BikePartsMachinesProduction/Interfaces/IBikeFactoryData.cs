using BikePartsMachinesProduction.Models.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Interfaces
{
    public interface IBikeFactoryData
    {
        IEnumerable<IPart> PartsList { get; }

        void AddPart(IPart part);

        IEnumerable<IMachine> MachinesList { get; }

        void AddMachine(IMachine machine);
    }
}
