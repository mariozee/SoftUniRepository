using System;
using System.Linq;
using System.Reflection;

namespace _01.ClassBox
{
    public class Startup
    {
        static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(lenght, width, height);
                var volume = box.CalculateVolume();
                var latSurface = box.CalculateLateralSurface();
                var surface = box.CalculateSurface();

                Console.WriteLine("Surface Area - {0:F2}", surface);
                Console.WriteLine("Lateral Surface Area - {0:F2}", latSurface);
                Console.WriteLine("Volume - {0:F2}", volume);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ParamName);
            }            
        }
    }
}