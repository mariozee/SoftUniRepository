using BikePartsMachinesProduction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsMachinesProduction.Enum;
using BikePartsMachinesProduction.Models.Parts;
using BikePartsMachinesProduction.Models.Parts.Frames;

namespace BikePartsMachinesProduction.Factory
{
    public class PartFactory : IPartFactory
    {
        public IPart CreateFrame(string frameType, double frameSize, double wheelSize)
        {
            switch (frameType)
            {
                case "Downhill":
                    return new DownHillFrame(frameSize, wheelSize);
                default:
                    throw new ArgumentException("Unsupported frame type");
            }
        }
    }
}
