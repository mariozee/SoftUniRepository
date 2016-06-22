using BikePartsFactory.Core;
using BikePartsFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BikePartsFactory.Menus
{
    public class FrameMenuCommandExecute : IFrameMenuCommandExecute
    {
        private IList<string> frameSpecification = new List<string>();

        public IList<string> FrameSpecification
        {
            get { return this.frameSpecification; }
        }

        public void ExecuteSelectFrameTypeMenu(
            IConsoleReader reader, 
            IConsoleWriter writer, 
            IConsoleClear clear, 
            IMenu menu,
            IEngine engine)
        {
            writer.WriteLine(menu.PrintSelectFrameTypeMenu());
            string input = reader.ReadLine();
            clear.Clear();

            switch (input)
            {
                case "1":
                    frameSpecification.Add("Downhill");
                    ExecuteSelectDownhillFrameSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "2":
                    frameSpecification.Add("Freeride");
                    ExecuteSelectFreerideFrameSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "3":
                    frameSpecification.Add("CrossCountry");
                    //ExecuteSelectDownhillFrameSizeMenu(reader, writer, clear, menu);
                    break;
                case "9":
                    engine.Run();
                    break;
                default:
                    break;
            }
        }

        #region Downhill Frame menu executer methods

        private void ExecuteSelectDownhillFrameSizeMenu(
            IConsoleReader reader, 
            IConsoleWriter writer, 
            IConsoleClear clear, 
            IMenu menu,
            IEngine engine)
        {
            writer.WriteLine(menu.PrintSelectDownhillFrameSizeMenu());
            string input = reader.ReadLine();
            clear.Clear();

            switch (input)
            {
                case "1":
                    frameSpecification.Add("15");
                    ExecuteSelectDownhillWheelSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "2":
                    frameSpecification.Add("17");
                    ExecuteSelectDownhillWheelSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "3":
                    frameSpecification.Add("19");
                    ExecuteSelectDownhillWheelSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "8":
                    frameSpecification.RemoveAt(0);
                    ExecuteSelectFrameTypeMenu(reader, writer, clear, menu, engine);
                    break;
                case "9":
                    this.frameSpecification.Clear();
                    engine.Run();
                    break;
                default:
                    break;
            }
        }

        private void ExecuteSelectDownhillWheelSizeMenu(
            IConsoleReader reader, 
            IConsoleWriter writer, 
            IConsoleClear clear, 
            IMenu menu,
            IEngine engine)
        {
            writer.WriteLine(menu.PrintSelectDownhillWheelSizeMenu());
            string input = reader.ReadLine();
            clear.Clear();

            switch (input)
            {
                case "1":
                    frameSpecification.Add("26");
                    ExecuteSelectDownhillModelNameMenu(reader, writer, clear, menu, engine);
                    break;
                case "2":
                    frameSpecification.Add("27.5");
                    ExecuteSelectDownhillModelNameMenu(reader, writer, clear, menu, engine);
                    break;
                case "8":
                    frameSpecification.RemoveAt(1);
                    ExecuteSelectDownhillFrameSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "9":
                    frameSpecification.Clear();
                    engine.Run();
                    break;
                default:
                    break;
            }
        }

        private void ExecuteSelectDownhillModelNameMenu(
            IConsoleReader reader, 
            IConsoleWriter writer, 
            IConsoleClear clear, 
            IMenu menu,
            IEngine engine)
        {
            writer.WriteLine(menu.PrintSelectDownhillModelNameMenu());
            string input = reader.ReadLine();
            clear.Clear();

            switch (input)
            {
                case "1":
                    frameSpecification.Add("TreeCutter");
                    break;
                case "2":
                    frameSpecification.Add("GroundCrusher");
                    break;
                case "8":
                    frameSpecification.RemoveAt(2);
                    ExecuteSelectDownhillWheelSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "9":
                    frameSpecification.Clear();
                    engine.Run();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Freeride Frame menu executer methods

        private void ExecuteSelectFreerideFrameSizeMenu(
            IConsoleReader reader,
            IConsoleWriter writer,
            IConsoleClear clear,
            IMenu menu,
            IEngine engine)
        {
            writer.WriteLine(menu.PrintSelectFreerideFrameSizeMenu());
            string input = reader.ReadLine();
            clear.Clear();

            switch (input)
            {
                case "1":
                    frameSpecification.Add("17");
                    ExecuteSelectFreerideWheelSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "2":
                    frameSpecification.Add("19");
                    ExecuteSelectFreerideWheelSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "3":
                    frameSpecification.Add("21");
                    ExecuteSelectFreerideWheelSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "8":
                    frameSpecification.RemoveAt(0);
                    ExecuteSelectFrameTypeMenu(reader, writer, clear, menu, engine);
                    break;
                case "9":
                    engine.Run();
                    break;
                default:
                    break;
            }
        }

        private void ExecuteSelectFreerideWheelSizeMenu(
            IConsoleReader reader,
            IConsoleWriter writer,
            IConsoleClear clear,
            IMenu menu,
            IEngine engine)
        {
            writer.WriteLine(menu.PrintSelectFreerideWheelSizeMenu());
            string input = reader.ReadLine();
            clear.Clear();

            switch (input)
            {
                case "1":
                    frameSpecification.Add("26");
                    ExecuteSelectFreerideModelNameMenu(reader, writer, clear, menu, engine);
                    break;
                case "2":
                    frameSpecification.Add("27.5");
                    ExecuteSelectFreerideModelNameMenu(reader, writer, clear, menu, engine);
                    break;
                case "3":
                    frameSpecification.Add("29");
                    ExecuteSelectFreerideModelNameMenu(reader, writer, clear, menu, engine);
                    break;
                case "8":
                    frameSpecification.RemoveAt(1);
                    ExecuteSelectFreerideFrameSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "9":
                    frameSpecification.Clear();
                    engine.Run();
                    break;
                default:
                    break;
            }
        }

        private void ExecuteSelectFreerideModelNameMenu(
            IConsoleReader reader,
            IConsoleWriter writer,
            IConsoleClear clear,
            IMenu menu,
            IEngine engine)
        {
            writer.WriteLine(menu.PrintSelectFreerideModelNameMenu());
            string input = reader.ReadLine();
            clear.Clear();

            switch (input)
            {
                case "1":
                    frameSpecification.Add("TreeCutter");
                    break;
                case "2":
                    frameSpecification.Add("GroundCrusher");
                    break;
                case "8":
                    frameSpecification.RemoveAt(2);
                    ExecuteSelectFreerideWheelSizeMenu(reader, writer, clear, menu, engine);
                    break;
                case "9":
                    frameSpecification.Clear();
                    engine.Run();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
