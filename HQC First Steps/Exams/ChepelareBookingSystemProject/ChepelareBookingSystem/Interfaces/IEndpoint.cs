using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChepelareBookingSystem.Interfaces
{
    public interface IEndpoint
    {
        string ControllerName { get; }
        string ActionName { get; }
        IDictionary<string, string> Parameters { get; }
    }
}
