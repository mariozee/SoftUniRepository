namespace TheSlum.Bonuses
{
    class Pill : Bonus
    {
        private const int AttackEffectConst = 100;

        public Pill(string id, int healthEffect = 0, int defenseEffect= 0, int attackEffect = AttackEffectConst)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }
    }
}
