using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Parts.Frames
{
    public class DownhillFrame : Frame
    {
        private const string FrameType = "Downhill";
        private double frameSize;
        private double wheelSize;
        private int modelNumer;
        private static int descendingModelNumber = 0;

        public DownhillFrame(double frameSize, double wheelSize, string modelName)
            : base(FrameType, frameSize, wheelSize, modelName)
        {
            this.modelNumer = descendingModelNumber++;
            this.FrameSize = frameSize;
            this.wheelSize = wheelSize;
            this.ModelName = modelName;
        }

        public override double FrameSize
        {
            get
            {
                return this.frameSize;
            }

            set
            {
                this.frameSize = value;
            }
        }

        public override double WheelSize
        {
            get
            {
                return this.wheelSize;
            }

            set
            {
                this.wheelSize = value;
            }
        }

        public override int ModelNumber
        {
            get
            {
                return this.modelNumer;
            }
        }
    }
}
