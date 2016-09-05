namespace Blobs.Models.Behaviors
{
    using System;
    using Interfaces;

    public class Aggressive : IBehavior
    {
        private const int DamageLoose = 5;
        private const int DamageModifier = 2;

        public void Behave(IBlob blob)
        {
            blob.Damage *= DamageModifier;
        }

        public void Update(IBlob blob)
        {
            if (blob.IsAlive() && blob.Damage - DamageLoose >= blob.InitialDamamge)
            {
                blob.Damage -= DamageLoose;
            }
        }
    }
}