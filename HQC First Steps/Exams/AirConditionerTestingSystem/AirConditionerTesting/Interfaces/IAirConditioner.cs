using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerTesting.Interfaces
{
    //DI: Addet interface for all air conditioners
    public interface IAirConditioner
    {
        string Manufacturer { get; }

        string Model { get; }

        int Test();
    }
}
