using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    using CustomListMain;

    public class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> a = new CustomList<int>();

            a.Add(5);
            a.Add(6);
            a.Add(1006);
            a.Add(234);
            a.Add(53);
            a.Add(234);

            a.RemoveAll(234);
                
            for (int i = 0; i < a.GetLenght(); i++)
            {
                a.PrintValueAt(i);
            }

            Type type = typeof(CustomList<>);

            var attributes = type.GetCustomAttributes(false);
            foreach (var attribute in attributes)
            {
                double version = ((Version)attribute).Ver;
                Console.WriteLine(version);
            }

            
        }
    }
}
