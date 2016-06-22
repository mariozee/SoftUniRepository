using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Interfaces
{
    public interface IPart
    {
        string Brand { get; }

        string ModelName { get; }

        int ModelNumber { get; }
    }
}
