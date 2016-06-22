using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Interfaces
{
    public interface IFrame : IPart
    {
        string FrameType { get; }

        double FrameSize { get; }

        double WheelSize { get; }
    }
}
