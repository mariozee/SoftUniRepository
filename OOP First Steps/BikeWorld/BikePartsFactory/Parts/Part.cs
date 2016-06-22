using BikePartsFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BikePartsFactory.Parts
{
    public abstract class Part : IPart
    {
        private string brand = "MThree";
        private string modelName;

        public Part(string modelName)
        {
            this.ModelName = modelName;
        }

        public string Brand
        {
            get { return this.brand; }
        }

        public string ModelName
        {
            get { return this.modelName; }
            set { this.modelName = value; }
        }

        public abstract int ModelNumber { get; }
    }
}
