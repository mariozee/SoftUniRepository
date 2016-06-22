using BikePartsFactory.Core.ProductionManager;
using BikePartsFactory.PartProductionProceses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Interfaces
{
    public interface IFrameProductionManager
    {
        FrameProductionProces StartProces(
            string frameType,
            double frameSize,
            double wheelSize,
            string modelName,
            IFrameFactory frameFactory);       
    }
}
