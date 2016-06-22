using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3.Interfaces
{
    interface ISale
    {
        string Name { get; set; }

        DateTime Date { get; set; }

        decimal Price { get; set; }
    }
}
