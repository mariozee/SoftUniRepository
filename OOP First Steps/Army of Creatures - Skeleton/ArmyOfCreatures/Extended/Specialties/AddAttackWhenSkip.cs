namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Specialties;
    using System;
    using Logic.Battles;
    using System.Globalization;

    public class AddAttackWhenSkip : Specialty
    {
        private const int MinAttackPoints = 1;
        private const int MaxAttackPoints = 10;
        private int attackPoints;

        public AddAttackWhenSkip(int attackPoints)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set
            {
                if (value < MinAttackPoints || value > MaxAttackPoints)
                {
                    string message = string.Format("The number of the attack points must be between {0} and {1}",
                        MinAttackPoints,
                        MaxAttackPoints);

                    throw new ArgumentOutOfRangeException("attackPoints", message);
                }

                this.attackPoints = value;
            }
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.AttackPoints;
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {

        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {       
        }

        public override string ToString()
        {
            string output = string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.AttackPoints);
            return base.ToString();
        }
    }
}
