using BikePartsMachinesProduction.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Interfaces
{
    public interface IPartFactory
    {
        IPart CreateFrame(string partType, double frameSize, double wheelSize);
    }
}
