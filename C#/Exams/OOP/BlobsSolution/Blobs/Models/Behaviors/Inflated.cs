namespace Blobs.Models.Behaviors
{
    using System;
    using Interfaces;

    public class Inflated : IBehavior
    {
        private const int HealthBonus = 50;
        private const int HealthLoose = 10;

        public void Behave(IBlob blob)
        {
            blob.Health += HealthBonus;
        }

        public void Update(IBlob blob)
        {
            //if (blob.IsAlive())
            //{
            //    blob.Health -= HealthLoose;
            //}

            blob.Health -= HealthLoose;
        }
    }
}