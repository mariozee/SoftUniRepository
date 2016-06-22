using Problem3.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3.Interfaces
{
    interface IEmployee
    {
        decimal Salary { get; set; }
        Department Department { get; set; }
    }
}
