using BikePartsMachinesProduction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            string message = Console.ReadLine();

            return message;
        }
    }
}
