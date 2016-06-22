namespace ArmyOfCreatures.Extended.Creatures
{
    using Specialties;
    using Logic.Creatures;

    public class WolfRaider : Creature
    {
        private const int DefaultWolfRiderAttack = 8;
        private const int DefaultWolfRiderDefense = 5;
        private const int DefaultWolfRiderHealth = 10;
        private const decimal DefaultWolfRiderDamage = 3.5m;
        private const int WolfRiderDoubleDamageRoundsDuration = 7;

        protected WolfRaider()
           : base(DefaultWolfRiderAttack, DefaultWolfRiderDefense,
                  DefaultWolfRiderHealth, DefaultWolfRiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(WolfRiderDoubleDamageRoundsDuration));
        }
    }
}
