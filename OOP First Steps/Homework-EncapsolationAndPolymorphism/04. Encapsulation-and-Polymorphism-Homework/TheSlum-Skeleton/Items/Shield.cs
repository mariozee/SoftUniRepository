namespace TheSlum.Items
{
    class Shield : Item
    {
        private const int DefenseEffectConst = 50;

        public Shield(string id, int healthEffect = 0, int defenseEffect = DefenseEffectConst, int attackEffect = 0)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }
    }
}
