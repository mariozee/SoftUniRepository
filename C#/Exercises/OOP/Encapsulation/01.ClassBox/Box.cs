using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBox
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get { return this.lenght; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Lenght cannot be zero or negative.");
                }

                this.lenght = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double CalculateVolume()
        {
            double result = this.lenght * this.width * this.height;
            return result;
        }

        public double CalculateLateralSurface()
        {
            double result = 2 * this.lenght * this.height + 2 * this.width * this.height;
            return result;
        }

        public double CalculateSurface()
        {
            double result = 2 * this.lenght * this.width + 2 * this.lenght * this.height + 2 * this.width * this.height;
            return result;
        }
    }
}
