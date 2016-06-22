using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Models.CombatHandlers
{
    public class WarriorCombatHandler : AbstractCombatHandler
    {
        public WarriorCombatHandler()
            : base()
        {

        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            List<IUnit> targets = new List<IUnit>();

            IEnumerable<IUnit> sortedByHealthAndNames = candidateTargets.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);
                
            try
            {
                targets.Add(sortedByHealthAndNames.ElementAt(0));
            }
            catch (ArgumentOutOfRangeException)
            {
                //skip
            }

            return targets;
        }

        public override ISpell GenerateAttack()
        {
            int damage = this.Unit.AttackPoints;
            int energyCost = 0;

            if (this.Unit.HealthPoints <= 80)
            {
                damage += (this.Unit.HealthPoints * 2);
            }

            if (this.Unit.HealthPoints > 50)
            {
                energyCost = 15;
            }

            ISpell spell = new Cleave(damage, energyCost);
            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(this.Unit.Name + " does not have enough energy to cast Cleave");
            }
            else
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
            }

            return spell;
        }
    }
}
