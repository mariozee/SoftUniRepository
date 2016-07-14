namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private const int MinModelNameLenght = 3;
        private const int MinPrice = 0;
        private const int MinHeight = 0;

        private decimal height;
        private string model;
        private decimal price;

        protected Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public MaterialType Material { get; }

        public decimal Height
        {
            get { return this.height; }
            protected set
            {
                if (value <= MinHeight)
                {
                    throw new ArgumentException();
                }

                this.height = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (value.Length < MinModelNameLenght)
                {
                    throw new ArgumentException();
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= MinPrice)
                {
                    throw new ArgumentException();
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            string output = $"Type: {this.GetType().Name}, Model: {this.Model}, Price: {this.Price}, Height: {this.Height}";

            return output;
        }
    }
}