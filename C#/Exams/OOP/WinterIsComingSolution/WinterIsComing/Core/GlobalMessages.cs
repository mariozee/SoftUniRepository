namespace WinterIsComing.Core
{
    using System;

    public static class GlobalMessages
    {
        public const string CellIsTaken = "There is another unit on that cell";
        public const string UnitNotPresent = "Current unit is not present in the matrix";
        public const string InvalidCoordinate = "Unit coordinate can not be out of the boudary of the matrix";
        public const string NotEnoghtEnergy = "{0} does not have enough energy to cast {1}";
        public const string NotSupportedUnit = "Not supported unit type";
        public const string CantBeNull = "Unit can not be null";
        public const string NotSupportedCommand = "Current command is not supported by the engine";
    }
}
