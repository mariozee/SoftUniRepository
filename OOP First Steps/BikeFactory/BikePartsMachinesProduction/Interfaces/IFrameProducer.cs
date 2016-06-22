using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Interfaces
{
    public interface IFrameProducer
    {
        IFrame ProduceFrame(string frameType, double frameSize, double wheelSize);
    }
}
