using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Interfaces
{
    public interface IFrameFactory
    {
        IFrame CreateFrame(string frameType, double frameSize, double wheelSize, string modelName);
    }
}
