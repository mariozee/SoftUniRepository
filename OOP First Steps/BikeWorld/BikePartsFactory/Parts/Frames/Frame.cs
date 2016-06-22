using BikePartsFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Parts.Frames
{
    public abstract class Frame : Part, IFrame
    {
        public Frame(string frameType, double frameSize, double wheelSize, string modelName)
            : base(modelName)
        {
            this.FrameType = frameType;
            this.FrameSize = frameSize;
            this.WheelSize = wheelSize;
        }

        public override int ModelNumber { get; }

        public abstract double FrameSize { get; set; }

        public abstract double WheelSize { get; set; }

        public string FrameType { get; }
    }
}
