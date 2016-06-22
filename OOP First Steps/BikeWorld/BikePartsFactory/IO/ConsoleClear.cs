using BikePartsFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.IO
{
    class ConsoleClear : IConsoleClear
    {
        public void Clear()
        {
            Console.Clear();
        }
    }
}
