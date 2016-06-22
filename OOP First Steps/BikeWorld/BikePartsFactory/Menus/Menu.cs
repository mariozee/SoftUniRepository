using BikePartsFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Menus
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
            output.AppendLine("2: Create Frame");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        
        public string PrintSelectFrameTypeMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}     FRAME TYPE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: Downhill Frame");
            output.AppendLine("2: Freeride Frame");
            output.AppendLine("3: Cross Coutry Frame");
            output.AppendLine("9: HOME");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        #region Downhill Frame menu printing methods

        public string PrintSelectDownhillFrameSizeMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}   DOWNHILL FRAME SIZE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: 15\"");
            output.AppendLine("2: 17\"");
            output.AppendLine("3: 19\"");
            output.AppendLine("8: BACK");
            output.AppendLine("9: HOME");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        public string PrintSelectDownhillWheelSizeMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}  DOWNHILL WHEEL SIZE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: 26\"");
            output.AppendLine("2: 27.5\"");
            output.AppendLine("8: BACK");
            output.AppendLine("9: HOME");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        public string PrintSelectDownhillModelNameMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}  DOWNHILL MODEL TYPE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: TreeCutter");
            output.AppendLine("2: GroudCrusher");
            output.AppendLine("8: BACK");
            output.AppendLine("9: HOME");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }
        #endregion

        #region Freeride Frame menu printing methods

        public string PrintSelectFreerideFrameSizeMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}   FREERIDE FRAME SIZE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: 17\"");
            output.AppendLine("2: 19\"");
            output.AppendLine("3: 21\"");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        public string PrintSelectFreerideWheelSizeMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}  FREERIDE WHEEL SIZE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: 26\"");
            output.AppendLine("2: 27.5\"");
            output.AppendLine("3: 29\"");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        public string PrintSelectFreerideModelNameMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}  FREERIDE MODEL TYPE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: TreeCutter");
            output.AppendLine("2: GroudCrusher");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }
        #endregion

        #region Cross Country Frame menu printing methods

        public string PrintSelectCrossCountryFrameSizeMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}   CROSSCOUNTRY FRAME SIZE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: 17\"");
            output.AppendLine("2: 19\"");
            output.AppendLine("3: 21\"");
            output.AppendLine("4: 23\"");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        public string PrintSelectCrossCountryWheelSizeMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}  CROSSCOUNTRY WHEEL SIZE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: 27.5\"");
            output.AppendLine("2: 29\"");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }

        public string PrintSelectCrossCountryModelNameMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("{1}{0}  CROSSCOUNTRY MODEL TYPE{0}{1}{0}",
                Environment.NewLine,
                new string('-', 25));

            output.AppendLine("1: TreeCutter");
            output.AppendLine("2: GroudCrusher");
            output.AppendLine(new string('-', 25));

            return output.ToString();
        }
        #endregion
    }
}
