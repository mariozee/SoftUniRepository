using BikePartsMachinesProduction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsMachinesProduction.Core
{
    public class Menu : IMenu
    {


        public string PrintStartingMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}          MENU{0}{1}{0}", 
                Environment.NewLine, 
                new string('-', 25));

            output.AppendLine("1: View");
            output.AppendLine("2: Create");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        public string PrintViewMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}          VIEW{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: View Machines");
            output.AppendLine("2: View Parts");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        public string PrintCreateMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}        CREATE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: Create Machine");
            output.AppendLine("2: Create Part");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }


    }
}
