using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsMachinesProduction.Enum;
using BikePartsMachinesProduction.Interfaces;
using BikePartsMachinesProduction.Factory;

namespace BikePartsMachinesProduction.Models.Machines
{
    public class FrameMachine : Machine
    {
        private const PartType PartTypeName = PartType.Frame;
        private IPartFactory partFactory;
        //private string frameType;
        //private double frameSize;
        //private double wheelSize;
        
        public FrameMachine()
            : base(PartTypeName)
        {
        }

        public override IFrame ProduceFrame(string frameType, double frameSize, double wheelSize)
        {
            throw new NotImplementedException();
        }

        //public override IFrame ProduceFrame(string frameType, double frameSize, double wheelSize)
        //{

        //}
    }
}
