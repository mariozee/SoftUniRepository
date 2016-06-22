namespace Blob.Models.Behaviours
{
    public class InflatedBehavior : Behaviour
    {
        private const int DamageBonus = 0;
        private const int HealthBonus = 50;
        private const int HealthDescendingRate = 10;
        private const int DamageDescendingRate = 0;
        public InflatedBehavior(int blobDamage)
            : base(DamageBonus, HealthBonus, DamageDescendingRate, HealthDescendingRate, blobDamage)
        {
        }
    }
}
