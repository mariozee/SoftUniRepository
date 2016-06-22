using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsMachinesProduction.Interfaces;

namespace BikePartsMachinesProduction.BikeFactoryData
{
    public class BikeFactoryData : IBikeFactoryData
    {
        private IList<IMachine> machinesList = new List<IMachine>();
        private IList<IPart> partsList = new List<IPart>();

        //public BikeFactoryData()
        //{
        //    this.MachinesList = new List<IMachine>();
        //    this.PartsList = new List<IPart>();
        //}

        public IEnumerable<IMachine> MachinesList
        {
            get { return this.machinesList; }
        }

        public IEnumerable<IPart> PartsList
        {
            get { return this.partsList; }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException(nameof(machine));
            }

            this.machinesList.Add(machine);
        }

        public void AddPart(IPart part)
        {
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part));
            }

            this.partsList.Add(part);
        }
    }
}
