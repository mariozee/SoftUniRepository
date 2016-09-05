namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Spells;
    using Core.Exceptions;
    using Core;

    public class IceGiantCombatHandler : CombatHandler
    {
        private const int AttackPointsIncreasment = 5;

        public override ISpell GenerateAttack()
        {
            Stomp stomp = new Stomp(this.Unit.AttackPoints);
            if (this.Unit.EnergyPoints < stomp.EnergyCost)
            {
                throw new GameException(string.Format(GlobalMessages.NotEnoghtEnergy, this.Unit.Name, stomp.GetType().Name));
            }

            this.Unit.EnergyPoints -= stomp.EnergyCost;
            this.Unit.AttackPoints += AttackPointsIncreasment;

            return stomp;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = new List<IUnit>();
            if (this.Unit.HealthPoints <= 150)
            {
                var target = candidateTargets.FirstOrDefault();
                if (target != null)
                {
                    targets.Add(target);
                }

                return targets;
            }

            return candidateTargets;
        }
    }
}
