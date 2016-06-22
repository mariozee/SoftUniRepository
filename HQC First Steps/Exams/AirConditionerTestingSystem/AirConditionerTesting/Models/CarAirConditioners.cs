namespace AirConditionerTesting.Models
{
    using System;
    using Interfaces;
    using Core;

    public class CarAirConditioners : IAirConditioner
    {
        private string manufacturer;
        private int volumeCovered;

        public CarAirConditioners(string manufacturer, string model, int volumeCoverage)
        {
            Manufacturer = manufacturer;
            Model = model;
            VolumeCovered = volumeCoverage;
        }

        public string model;

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < GlobalMessages.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(GlobalMessages.INCORRECT_PROPERTY_LENGTH, "Model", 2));
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < GlobalMessages.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(GlobalMessages.INCORRECT_PROPERTY_LENGTH, "Manufacturer", 4));
                }

                this.manufacturer = value;
            }
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
                    throw new ArgumentException(string.Format(GlobalMessages.NONPOSITIVE, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public int Test()
        {
            double sqrtVolume = Math.Sqrt(volumeCovered);
            if (sqrtVolume < 3)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                           this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";
            print += "Volume Covered: " + VolumeCovered + "\r\n";

            print += "====================";

            return print;
        }
    }
}
