using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3.Interfaces
{
    using Enum;
    interface IProject
    {
        string Name { get; set; }

        DateTime Start { get; set; }

        string Details { get; set; }

        State State { get; set; }
    }
}
