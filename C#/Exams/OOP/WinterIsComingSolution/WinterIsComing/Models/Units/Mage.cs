namespace WinterIsComing.Models.Units
{
    using Interfaces;
    using Enums;
    using CombatHandlers;

    public class Mage : Unit
    {        
        private const int AttackPointsDefault = 80;
        private const int HealthPointsDefault = 80;
        private const int DefensePointsDefault = 40;
        private const int EnergyPointsDefault = 120;
        private const int RangeDefault = 2;

        public const UnitType Type = UnitType.Mage;

        public Mage(string name, int x, int y )
                    : base(AttackPointsDefault, HealthPointsDefault, EnergyPointsDefault, DefensePointsDefault, RangeDefault, name, x, y)
        {
            this.CombatHandler = new MageCombatHandler();
            this.CombatHandler.Unit = this;
        }
    }
}
