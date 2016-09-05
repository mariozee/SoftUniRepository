namespace WinterIsComing.Models.Spells
{
    public class Stomp : Spell
    {
        private const int EnergyCost = 10;

        public Stomp(int damage)
            : base(damage, EnergyCost)
        {
        }
    }
}
