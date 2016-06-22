using System;
using Blob.Core;
using Blob.Interfaces;

namespace Blob.Models.Attacks
{
    public abstract class Attack : IAttack
    {
        private int damage;
        private int damageMultiplicator;

        protected Attack(int initialDamage, int damageMultiplicator)
        {
            this.Damage = initialDamage;

            if (damageMultiplicator <= 0)
                throw new ArgumentOutOfRangeException(string.Format(EngineMessages.MustBePositive, "damageMultiplicator"));

            this.damageMultiplicator = damageMultiplicator;
        }

        public abstract void ApplyEffect(IBlob blob);

        public int Damage
        {
            get { return this.damage * this.damageMultiplicator; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(string.Format(EngineMessages.MustBePositive, "Damage"));

                this.damage = value;
            }
        }
    }
}
