namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        private const int EnergyCost = 30;

        public FireBreath(int damage)
            : base(damage, EnergyCost)
        {
        }
    }
}
