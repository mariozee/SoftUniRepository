using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Homework.DistanceCalculator;


namespace Homework.Homework.Point3D
{
    public class Points
    {
        private static readonly Points startingPoint = new Points(0, 0, 0);

        public static Points StartingPoint
        {
            get { return startingPoint; }
            set { }
        }

        public Points(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }


        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }


        public override string ToString()
        {
            return String.Format("{3}Coordinate X: {0}{3}Coordinate Y: {1}{3}Coordinate Z: {2}{3}"
                , this.X, this.Y, this.Z, Environment.NewLine);
        }
    }
}
