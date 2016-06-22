namespace TheSlum.Models
{
    public class Axe : Item
    {
        private const int AttackEffectConst = 75;

        public Axe(string id, int healthEffect = 0, int defenseEffect = 0, int attackEffect = AttackEffectConst)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }
    }
}
