namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;

    public class Chair : Furniture, IChair
    {
        private const int MinChairLegs = 2;

        private int numberOfLegs;

        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
            private set
            {
                if (value < MinChairLegs)
                {
                    throw new ArgumentException();
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            string output = $"{base.ToString()}, Legs: {this.NumberOfLegs}";

            return output;
        }
    }
}
