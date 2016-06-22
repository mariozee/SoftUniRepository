using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Models.Parts.Frames
{
    public class DownHillFrame : Frame
    {
        private const string DownHillFrameType = "Downhill";
        private int modelNumber = 0;
        private static int modelNumberIncrecment = 1;

        public DownHillFrame(double frameSize, double wheelSize)
            : base(DownHillFrameType, frameSize, wheelSize)
        {
            this.modelNumber = modelNumberIncrecment++;
        }

        public override int ModelNumber
        {
            get
            {
                return this.modelNumber;
            }
        }
    }
}
