using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace BikePartsFactory.Interfaces
{
    public interface IMenu
    {
        string PrintStartingMenu();

        string PrintSelectFrameTypeMenu();

        string PrintSelectDownhillFrameSizeMenu();

        string PrintSelectDownhillWheelSizeMenu();

        string PrintSelectDownhillModelNameMenu();

        string PrintSelectFreerideFrameSizeMenu();

        string PrintSelectFreerideWheelSizeMenu();

        string PrintSelectFreerideModelNameMenu();

        string PrintSelectCrossCountryFrameSizeMenu();

        string PrintSelectCrossCountryWheelSizeMenu();

        string PrintSelectCrossCountryModelNameMenu();
    }
}
