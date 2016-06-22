using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Interfaces;
using WinterIsComingMain.Models.Units;

namespace WinterIsComingMain.Core
{
    public static class UnitFactory
    {
        public static IUnit Create(EnumUnitType type, string name, int x, int y)
        {
            switch (type)
            {
                case EnumUnitType.Warrior:
                    return new Warrior(name, x, y);
                case EnumUnitType.Mage:
                    return new Mage(name, x, y);
                case EnumUnitType.IceGiant:
                    return new IceGiant(name, x, y);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
