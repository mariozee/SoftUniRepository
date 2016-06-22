using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Homework.Point3D;


namespace Homework.Homework.DistanceCalculator
{
    public class DisCalc
    {
        public static double CalculateDistance(Points p1, Points p2)
        {
            double deltaX = Math.Pow(p1.X - p2.X, 2);
            double deltaY = Math.Pow(p1.Y - p2.Y, 2);
            double deltaZ = Math.Pow(p1.Z - p2.Z, 2);

            return Math.Sqrt(deltaX + deltaY + deltaZ);
        }
    }
}
