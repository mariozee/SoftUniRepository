using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsFactory.Parts.Frames;
using BikePartsFactory.Interfaces;

namespace BikePartsFactory.Core.Factory
{
    public class FrameFactory : IFrameFactory
    {
        public IFrame CreateFrame(string frameType, double frameSize, double wheelSize, string modelName)
        {
            switch (frameType)
            {
                case "CrossCountry":
                    return new CrossCountryFrame(frameSize, wheelSize, modelName);
                case "Downhill":
                    return new DownhillFrame(frameSize, wheelSize, modelName);
                case "Freeride":
                    return new FreerideFrame(frameSize, wheelSize, modelName);
                default:
                    throw new Exception();
            }
        }
    }
}
