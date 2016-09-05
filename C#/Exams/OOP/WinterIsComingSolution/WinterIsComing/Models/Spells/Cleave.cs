namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spell
    {
        private const int EnergyCost = 15;

        public Cleave(int damage)
            : base(damage, EnergyCost)
        {
        }
    }
}
