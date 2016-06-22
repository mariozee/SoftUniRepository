namespace AirConditionerTesting.Models
{
    using Core;
    using Interfaces;
    using System;

    public class StationaryAirConditioners : IAirConditioner
    {
        private int powerUsage;
        private string manufacturer;
        private string model;
        public int energyRating;

        public StationaryAirConditioners(string manufacturer,
            string model,
            string ennergyEfficiencyRating,
            int powerUsage)
        {
            Manufacturer = manufacturer;
            Model = model;
            switch (ennergyEfficiencyRating)
            {
                case "A":
                    energyRating = 10;
                    break;
                case "B":
                    energyRating = 12;
                    break;
                case "C":
                    energyRating = 15;
                    break;
                case "D":
                    energyRating = 20;
                    break;
                case "E":
                    energyRating = 90;
                    break;
                default:
                    throw new ArgumentException(GlobalMessages.INCORRECTRATING);
            }

            this.powerUsage = powerUsage;
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

        public int Test()
        {
            if (this.powerUsage / 100 <= this.energyRating)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                           this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

            string energy = "A";
            switch (energyRating)
            {
                case 12:
                    energy = "B";
                    break;
                case 15:
                    energy = "C";
                    break;
                case 20:
                    energy = "D";
                    break;
                case 90:
                    energy = "E";
                    break;
                default:
                    throw new ArgumentException(GlobalMessages.INCORRECTRATING);
                    
            }

            print += "Required energy efficiency rating: " + energy + "\r\n" + "Power Usage(KW / h): " +
                         this.powerUsage + "\r\n";

            print += "====================";

            return print.ToString();
        }        
    }
}
