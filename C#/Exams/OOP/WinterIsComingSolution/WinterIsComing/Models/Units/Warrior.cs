namespace WinterIsComing.Models.Units
{
    using Interfaces;
    using Enums;
    using CombatHandlers;

    public class Warrior : Unit
    {
        private const int AttackPointsDefault = 120;
        private const int HealthPointsDefault = 180;
        private const int DefensePointsDefault = 70;
        private const int EnergyPointsDefault = 60;
        private const int RangeDefault = 1;

        public const UnitType Type = UnitType.Warrior;

        public Warrior(string name, int x, int y)
                    : base(AttackPointsDefault, HealthPointsDefault, EnergyPointsDefault, DefensePointsDefault, RangeDefault, name, x, y)
        {
            this.CombatHandler = new WarriorCombatHandler();
            this.CombatHandler.Unit = this;
        }
    }
}
