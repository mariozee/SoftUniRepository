namespace Blobs.Models.Attacks
{
    using System;
    using Interfaces;

    public class Blobplode : IAttack
    {        
        private const int HealthModifier = 2;

        public int BonusAttack { get; private set; }

        public void ModifyStats(IBlob blob)
        {
            this.BonusAttack = 0;
            this.BonusAttack = blob.Damage * 2;
            blob.Health /= HealthModifier;
        }
    }
}
