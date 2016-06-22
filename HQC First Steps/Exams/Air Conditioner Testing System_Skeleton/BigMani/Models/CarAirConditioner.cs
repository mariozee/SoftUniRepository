using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMani.Models
{
    public class CarAirConditioner : Airconditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCovered)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException(string.Format(GoodStuff.GoodStuff.NONPOSITIVE, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(volumeCovered);
            if (sqrtVolume < 3)
            {
                return 1;
            }

            return 2;
        }

        public override string ToString()
        {
            string output = string.Format("{0}{1}Volume Covered: {2}",
                base.ToString(), Environment.NewLine, this.VolumeCovered);

            return output;
        }
    }
}
