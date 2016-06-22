using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Homework.Point3D;
using Homework.Homework.DistanceCalculator;
using Homework.Homework.Path3D;
using System.IO;
using Homework.Homework.Storage;

namespace Homework
{
    public class HomeworkMain
    {

        static void Main(string[] args)
        {
            Points b1 = new Points(2, 4, 5);
            Points b2 = new Points(12, 13, 15);
            Paths c = new Paths(b1, b2);

            Console.Write("Enter file name:");

            string save = Console.ReadLine();

            Console.Write("Do you want to save the file? (Y / N): ");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {

            }
            string open = @"C:\Users\Zisov4eto\Desktop\" + save + ".txt";

            //Stor.SaveFile(save, c);

            //ArrayReader(c);

           Stor.ReadFile(open);

            
        }
        //Print Array
        //public static void ArrayReader(Paths arr)
        //{
        //    foreach (var item in arr.Arr)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
    }
}
