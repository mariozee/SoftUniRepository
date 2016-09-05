namespace WinterIsComing.Models.Spells
{
    using System;
    using Interfaces;

    public abstract class Spell : ISpell
    {
        private int damage;
        private int energyCost;

        protected Spell(int damage, int energyCost)
        {
            this.damage = damage;
            this.energyCost = energyCost;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            private set
            {
                this.damage = value;
            }
        }

        public int EnergyCost
        {
            get
            {
                return this.energyCost;
            }
            private set
            {
                this.energyCost = value;
            }
        }
    }
}
