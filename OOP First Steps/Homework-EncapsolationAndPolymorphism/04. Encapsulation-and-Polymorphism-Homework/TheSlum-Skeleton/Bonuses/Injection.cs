namespace TheSlum.Bonuses
{
    class Injection : Bonus
    {
        private const int HealthEffectConst = 200;

        public Injection(string id, int healthEffect = HealthEffectConst, int defenseEffect = 0, int attackEffect = 0)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {   
        }

        
    }
}
