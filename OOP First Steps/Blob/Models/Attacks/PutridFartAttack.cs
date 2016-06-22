using Blob.Interfaces;

namespace Blob.Models.Attacks
{
    public class PutridFartAttack : Attack
    {
        private const int PutridFartMultipicator = 1;
        public PutridFartAttack(int initialDamage)
            : base(initialDamage, PutridFartMultipicator)
        {
        }

        public override void ApplyEffect(IBlob blob)
        {
            //Nothing
        }
    }
}
