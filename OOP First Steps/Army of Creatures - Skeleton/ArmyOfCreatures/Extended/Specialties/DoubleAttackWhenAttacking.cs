namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using Logic.Battles;
    using Logic.Specialties;

    class DoubleAttackWhenAttacking : Specialty
    {
        private const int MinimumRounds = 1;
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get { return this.rounds; }
            set
            {
                if (value < MinimumRounds)
                {
                    throw new ArgumentOutOfRangeException("rounds", "Rounds must be greather than 0");
                }

                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("defenderWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("attacker");
            }

            if (this.Rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }
    }
}
