using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3.Interfaces
{
    interface ISaleEmployee
    {
        List<Sale> Sales { get; set; }
    }
}
