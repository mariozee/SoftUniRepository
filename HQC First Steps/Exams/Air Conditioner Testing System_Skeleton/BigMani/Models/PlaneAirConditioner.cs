using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMani.Models
{
    public class PlaneAirConditioner : Airconditioner
    {
        private int volumeCovered;
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCovered, int electricityUsed)
            : base(manufacturer, model)
        {
            this.volumeCovered = volumeCovered;
            this.ElectricityUsed = electricityUsed;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException(string.Format(GoodStuff.GoodStuff.NONPOSITIVE, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(GoodStuff.GoodStuff.NONPOSITIVE, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(volumeCovered);
            if (this.ElectricityUsed / sqrtVolume < GoodStuff.GoodStuff.MinPlaneElectricity)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            string resutl = string.Format("{0}{1}Volume Covered: {2}{1}, Electricity Used {3}",
                ToString(), Environment.NewLine, this.VolumeCovered, this.ElectricityUsed);
            return base.ToString();
        }
    }
}
