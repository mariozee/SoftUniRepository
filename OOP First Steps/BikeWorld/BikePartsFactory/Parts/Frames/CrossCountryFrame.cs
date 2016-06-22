using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Parts.Frames
{
    public class CrossCountryFrame : Frame
    {
        private const string FrameType = "CrossCountry";
        private double frameSize;
        private double wheelSize;
        private int modelNumer;
        private static int descendingModelNumber = 0;

        public CrossCountryFrame(double frameSize, double wheelSize, string modelName)
            : base(FrameType, frameSize, wheelSize, modelName)
        {
            this.modelNumer = descendingModelNumber++;
            this.FrameSize = frameSize;
            this.WheelSize = wheelSize;
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
