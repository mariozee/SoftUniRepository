using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsFactory.Core.Factory;
using BikePartsFactory.Interfaces;

namespace BikePartsFactory.PartProductionProceses
{
    public class FrameProductionProces : PartProductionProces, IFrameProductionProces
    {
        private string partType = "Frame";
        private string frameType;
        private double frameSize;
        private double wheelSize;
        private string modelName;
        private bool canProducePart;
        private IFrameFactory frameFactory;

        public FrameProductionProces(
            string frameType, 
            double framSize, 
            double wheelSize, 
            string modelName,
            IFrameFactory frameFactory)
        {
            this.FrameType = frameType;
            this.FrameSize = framSize;
            this.WheelSize = wheelSize;
            this.ModelName = modelName;
            this.frameFactory = frameFactory;
        }

        public string FrameType { get; }

        public double FrameSize { get; }

        public double WheelSize { get; }

        public string ModelName { get; }

        public override bool CanProducePart
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override IPart ProducePart()
        {
            IFrame frame = this.frameFactory.CreateFrame(this.FrameType, this.FrameSize, this.WheelSize, this.ModelName);

            return frame;
        }
    }
}
