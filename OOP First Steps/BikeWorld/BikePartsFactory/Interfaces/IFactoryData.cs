using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Interfaces
{
    public interface IFactoryData
    {
        IEnumerable<IPart> PartsList { get; }

        void AddPartToList(IPart part);
    }
}
