namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Specialties;
    using System;
    using Logic.Battles;
    using System.Globalization;

    public class DoubleDamage : Specialty
    {
        private const int MinRoundDuration = 1;
        private const int MaxRoundDuration = 10;
        private int rounds;

        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get { return this.rounds; }
            set
            {
                if (value < MinRoundDuration || value > MaxRoundDuration)
                {
                    string message = string.Format("the number of the rounds must be between {0} and {1}"
                        , MinRoundDuration
                        , MaxRoundDuration);

                    throw new ArgumentOutOfRangeException("round", message);
                }
                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds < MinRoundDuration)
            {
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
            throw new NotImplementedException();
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            throw new NotImplementedException();
        }


        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string output = string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Rounds);
            return output;
        }
    }
}
