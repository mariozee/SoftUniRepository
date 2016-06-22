using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3.Interfaces
{
    interface IManager : IEmployee
    {
        List<Employee> Employees { get; set; }
    }
}
