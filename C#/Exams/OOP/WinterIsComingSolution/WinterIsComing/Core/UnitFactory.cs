namespace WinterIsComing.Core
{
    using Enums;
    using Interfaces;
    using Models.Units;
    using Exceptions;

    public static class UnitFactory
    {
        public static IUnit CreateUnit(UnitType type, string name, int x, int y)
        {
            IUnit unit;

            switch (type)
            {
                case UnitType.Mage:
                    unit = new Mage(name, x, y);
                    break;
                case UnitType.Warrior:
                    unit = new Warrior(name, x, y);
                    break;
                case UnitType.IceGiant:
                    unit = new IceGiant(name, x, y);
                    break;
                default:
                    throw new GameException(GlobalMessages.NotSupportedUnit);
            }

            return unit;
        }
    }
}
