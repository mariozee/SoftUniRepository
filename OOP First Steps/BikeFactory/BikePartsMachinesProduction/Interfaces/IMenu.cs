using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Interfaces
{
    public interface IMenu
    {
        string PrintStartingMenu();

        string PrintViewMenu();

        string PrintCreateMenu();
    }
}
