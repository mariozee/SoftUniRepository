using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsFactory.Interfaces;
using BikePartsFactory.PartProductionProceses;

namespace BikePartsFactory.Core.ProductionManager
{
    public class FrameProductionManager : IFrameProductionManager
    {
        public FrameProductionProces StartProces(
            string frameType, 
            double frameSize, 
            double wheelSize, 
            string modelName, 
            IFrameFactory 
            frameFactory)
        {
            return new FrameProductionProces(frameType, frameSize, wheelSize, modelName, frameFactory);
        }
    }
}
