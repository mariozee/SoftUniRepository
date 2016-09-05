namespace WinterIsComing.Models.CombatHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Spells;
    using Core.Exceptions;
    using Core;

    public class WarriorCombatHandler : CombatHandler
    {
        public override ISpell GenerateAttack()
        {
            Cleave cleave;
            if (this.Unit.HealthPoints <= 80)
            {
                int damage = this.Unit.AttackPoints + this.Unit.HealthPoints * 2;
                cleave = new Cleave(damage);
            }
            else
            {
                cleave = new Cleave(this.Unit.AttackPoints);
            }

            if (this.Unit.HealthPoints > 50)
            {
                if (this.Unit.EnergyPoints < cleave.EnergyCost)
                {
                    throw new GameException(string.Format(GlobalMessages.NotEnoghtEnergy, this.Unit.Name, cleave.GetType().Name));
                }

                this.Unit.EnergyPoints -= cleave.EnergyCost;
            }

            return cleave;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var target = candidateTargets.OrderBy(u => u.HealthPoints).ThenBy(u => u.Name).FirstOrDefault();

            var targets = new List<IUnit>();

            if (target != null)
            {
                targets.Add(target);
            }

            return targets;
        }
    }
}
