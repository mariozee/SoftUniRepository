namespace WinterIsComing.Models.Units
{
    using Interfaces;
    using Enums;
    using CombatHandlers;

    public class IceGiant : Unit
    {
        private const int AttackPointsDefault = 150;
        private const int HealthPointsDefault = 300;
        private const int DefensePointsDefault = 60;
        private const int EnergyPointsDefault = 50;
        private const int RangeDefault = 1;

        public const UnitType Type = UnitType.IceGiant;

        public IceGiant(string name, int x, int y)
                    : base(AttackPointsDefault, HealthPointsDefault, EnergyPointsDefault, DefensePointsDefault, RangeDefault, name, x, y)
        {
            this.CombatHandler = new IceGiantCombatHandler();
            this.CombatHandler.Unit = this;
        }
    }
}
