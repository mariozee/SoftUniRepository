using BigMani.GoodStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMani.Models
{
    public abstract class Airconditioner
    {
        private const int MinumumManufacturerNameLenght = 4;
        private const int MinumumModelNameLenght = 2;

        private string manufacturer;
        private string model;

        public Airconditioner(string manufacturer , string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            private set
            {
                if (value.Length < MinumumManufacturerNameLenght)
                {
                    throw new InvalidOperationException(string.Format(GoodStuff.GoodStuff.INCORRECT_PROPERTY_LENGTH,
                        "Manufacturer", MinumumManufacturerNameLenght));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (value.Length < MinumumModelNameLenght)
                {
                    throw new InvalidOperationException(string.Format(GoodStuff.GoodStuff.INCORRECT_PROPERTY_LENGTH,
                        "Model", MinumumModelNameLenght));
                }

                this.model = value;
            }
        }

        public abstract int Test();

        public override string ToString()
        {
            string output = string.Format("Air Conditioner{0}{1}{0}Manufacturer: {2}{0}Model: {3}",
                Environment.NewLine, new string(' ', 20), this.Manufacturer, this.Model);

            return output;
        }
    }
}
