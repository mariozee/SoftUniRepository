using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsFactory.Interfaces;

namespace BikePartsFactory.PartProductionProceses
{
    public abstract class PartProductionProces : IPartProductionProces
    {
        public abstract bool CanProducePart { get; }

        public abstract IPart ProducePart();
    }
}
