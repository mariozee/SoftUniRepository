using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMani.Models
{
    public class StationaryAirConditioner : Airconditioner
    {
        public StationaryAirConditioner(string manufacturer, string model, string energyEfficiency, int powerUsage)
            : base(manufacturer, model)
        {
            this.EnergyEfficiencyRating = GetRating(energyEfficiency);
            this.PowerUsege = powerUsage;
        }

        public int EnergyEfficiencyRating { get; private set; }

        public int PowerUsege { get; private set; }

        public override int Test()
        {
            if (this.PowerUsege / 100 <= this.EnergyEfficiencyRating)
            {
                return 1;
            }

            return 0;
        }

        private int GetRating(string energyEfficiency)
        {
            switch (energyEfficiency)
            {
                case "A":
                    return 10;
                case "B":
                    return 12;
                case "C":
                    return 15;
                case "D":
                    return 20;
                case "E":
                    return 90;
                default:
                    throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            string energyClass = string.Empty;
            switch (this.EnergyEfficiencyRating)
            {
                case 10:
                    energyClass = "A";
                    break;
                case 12:
                    energyClass = "B";
                    break;
                case 15:
                    energyClass = "C";
                    break;
                case 20:
                    energyClass = "D";
                    break;
                case 90:
                    energyClass = "E";
                    break;
            }

            string result = string.Format("{0}{1}Required energy efficiency rating: {2}{1}Power Usage(KW / h): {3}",
                ToString(), Environment.NewLine, energyClass, this.PowerUsege);

            return result;
        }
    }
}
