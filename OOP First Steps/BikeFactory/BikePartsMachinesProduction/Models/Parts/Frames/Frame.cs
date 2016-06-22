using BikePartsMachinesProduction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Models.Parts
{
    public abstract class Frame : IFrame
    {

        public Frame(string frameType, double frameSize, double wheelSize)
        {
            this.FrameType = frameType;
            this.FrameSize = frameSize;
            this.WheelSize = wheelSize;
        }

        public string FrameType { get; }

        public double FrameSize { get; }

        public double WheelSize { get; }

        public string Brand { get; }

        public abstract int ModelNumber { get; }
    }
}
