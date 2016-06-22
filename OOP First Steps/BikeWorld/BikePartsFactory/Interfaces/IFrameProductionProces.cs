using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Interfaces
{
    public interface IFrameProductionProces
    {
        string FrameType { get; }

        double FrameSize { get; }

        double WheelSize { get; }

        string ModelName { get; }
    }
}
