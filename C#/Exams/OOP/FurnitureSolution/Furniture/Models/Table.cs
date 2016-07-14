namespace FurnitureManufacturer.Models
{
    using System;
    using Interfaces;

    public class Table : Furniture, ITable
    {
        private const int MinSizeValue = 0;

        private decimal lenght;
        private decimal width;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal lenght, decimal width)
            : base(model, material, price, height)
        {
            this.Lenght = lenght;
            this.Width = width;
        }

        public decimal Area
        {
            get { return this.Lenght * this.Width; }
        }

        public decimal Lenght
        {
            get { return this.lenght; }
            private set
            {
                if (value <= MinSizeValue)
                {
                    throw new ArgumentException();
                }

                this.lenght = value;
            }
        }

        public decimal Width
        {
            get { return this.width; }
            private set
            {
                if (value <= MinSizeValue)
                {
                    throw new ArgumentException();
                }

                this.width = value;
            }
        }

        public override string ToString()
        {
            string output = $"{base.ToString()}, Lenght: {this.Lenght}, Width: {this.Width}, Area: {this.Area}";

            return output;
        }
    }
}