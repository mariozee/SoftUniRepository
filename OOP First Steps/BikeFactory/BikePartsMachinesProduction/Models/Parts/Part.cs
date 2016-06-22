using BikePartsMachinesProduction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Models.Parts
{
    public abstract class Part : IPart
    {
        private string brand = "Hell0ffAbr@nd";

        public string Brand
        {
            get { return this.brand; }
        }

        public int ModelNumber { get; }

        public override string ToString()
        {
            string output = string.Format("Brand: {0}{2}Product: {1}{2}",
                this.Brand,
                this.GetType().Name,
                Environment.NewLine);

            return output;
        }
    }
}
