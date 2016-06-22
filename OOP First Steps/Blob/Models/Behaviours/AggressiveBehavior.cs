using System.CodeDom;

namespace Blob.Models.Behaviours
{
    public class AggressiveBehavior : Behaviour
    {
        private const int HealthBonus = 0;
        private const int DamageDescendingRate = 5;
        private const int HealthDescendingRate = 0;
        public AggressiveBehavior(int blobDamage)
            : base(blobDamage, HealthBonus, DamageDescendingRate, HealthDescendingRate, blobDamage)
        {
        }
    }
}
