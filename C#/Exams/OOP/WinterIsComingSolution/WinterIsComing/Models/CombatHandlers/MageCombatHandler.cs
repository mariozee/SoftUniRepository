namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using Core;
    using Interfaces;
    using System.Linq;
    using System;
    using Spells;
    using Core.Exceptions;

    public class MageCombatHandler : CombatHandler
    {
        private const int FireBreathSwitch = 1;
        private const int BlizzardSwitch = 2;

        private int turn = FireBreathSwitch;

        public override ISpell GenerateAttack()
        {
            if (turn == FireBreathSwitch)
            {
                return this.GenarateFireBread();
            }
            else
            {
                return this.GenerateBlizzard();
            }
        }

        private ISpell GenarateFireBread()
        {
            FireBreath fireBreath = new FireBreath(this.Unit.AttackPoints);
            if (this.Unit.EnergyPoints < fireBreath.EnergyCost)
            {
                throw new GameException(string.Format(GlobalMessages.NotEnoghtEnergy, this.Unit.Name, fireBreath.GetType().Name));
            }

            this.Unit.EnergyPoints -= fireBreath.EnergyCost;
            this.turn = BlizzardSwitch;

            return fireBreath;
        }

        public ISpell GenerateBlizzard()
        {
            Blizzard blizzard = new Blizzard(this.Unit.AttackPoints * 2);
            if (this.Unit.EnergyPoints < blizzard.EnergyCost)
            {
                throw new GameException(string.Format(GlobalMessages.NotEnoghtEnergy, this.Unit.Name, blizzard.GetType().Name));
            }

            this.Unit.EnergyPoints -= blizzard.EnergyCost;
            this.turn = FireBreathSwitch;

            return blizzard;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var orderedTargets = candidateTargets.OrderByDescending(u => u.HealthPoints).ThenBy(u => u.Name).ToList();
            var targets = new List<IUnit>();

            int targetsCount = Math.Min(3, orderedTargets.Count);

            for (int i = 0; i < targetsCount; i++)
            {
                if (orderedTargets[i] != null)
                {
                    targets.Add(orderedTargets[i]);
                }
            }

            return targets;
        }
    }
}
