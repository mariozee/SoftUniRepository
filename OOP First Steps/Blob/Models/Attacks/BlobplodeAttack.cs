using Blob.Interfaces;

namespace Blob.Models.Attacks
{
    class BlobplodeAttack : Attack
    {
        private const int BlobplodeAttackMultipicator = 2;
        public BlobplodeAttack(int initialDamage)
            : base(initialDamage, BlobplodeAttackMultipicator)
        {
        }
        
        public override void ApplyEffect(IBlob blob)
        {
            blob.Health -= (blob.Health / 2);
        }
    }
}
