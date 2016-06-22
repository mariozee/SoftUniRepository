using BikePartsMachinesProduction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsMachinesProduction.Enum;

namespace BikePartsMachinesProduction.Models.Machines
{
    public abstract class Machine : IMachine
    {
        private PartType partType;
        private int partProductionDelay;
        private IPartFactory partFatory;

        public Machine(PartType partType)
        {
            this.partType = partType;
        }

        public MachineType MachineType { get; }

        public abstract IFrame ProduceFrame(string frameType, double frameSize, double wheelSize);

        public override string ToString()
        {
            string output = string.Format("Machine type: {0}", this.GetType().Name);

            return output;
        }

    }
}
