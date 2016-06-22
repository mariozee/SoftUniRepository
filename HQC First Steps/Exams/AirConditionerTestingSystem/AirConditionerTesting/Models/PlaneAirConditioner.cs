namespace AirConditionerTesting.Models
{
    using System;
    using Interfaces;
    using Core;

    public class PlaneAirConditioner : IAirConditioner
    {
        private string manufacturer;
        private int volumeCovered;
        private string model;
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            Manufacturer = manufacturer;
            Model = model;
            VolumeCovered = volumeCoverage;
            ElectricityUsed = Convert.ToInt32(electricityUsed);
        }

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
                    throw new ArgumentException(string.Format(GlobalMessages.NONPOSITIVE, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public int Test()
        {
            double sqrtVolume = Math.Sqrt(volumeCovered);
            if (this.ElectricityUsed / sqrtVolume < GlobalMessages.MinPlaneElectricity)
            {
                return 1;
            }

            return 0;
        }


        public override string ToString()
        {
            string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                           this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

            print += "Volume Covered: " + VolumeCovered + "\r\n" + "Electricity Used: " + ElectricityUsed + "\r\n";

            print += "====================";

            return print;
        }
    }
}
