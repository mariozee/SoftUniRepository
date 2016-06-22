using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Interfaces;
using WinterIsComingMain.Models.Spells;
using WinterIsComingMain.Exceptions;

namespace WinterIsComingMain.Models.CombatHandlers
{
    public class WarriorCombatHandler : AbstractCombatHandler
    {
        public override ISpell GenerateAttack()
        {
            int damage = this.Unit.AttackPoints;
            if (this.Unit.HealthPoints <= 80)
            {
                damage += this.Unit.HealthPoints * 2;
            }

            ISpell spell = new Cleave(damage);

            if (this.Unit.HealthPoints < 50)
            {
                return spell;
            }
            else
            {
                if (this.Unit.EnergyPoints < spell.EnergyCost)
                {

                    throw new NotEnoughtEnergyException(this.Unit.Name +
                        " does not have enogh energy to cast Cleave.");
                }
                else
                {
                    this.Unit.EnergyPoints -= spell.EnergyCost;

                    return spell;
                }
            }
        }

        public override IEnumerable<IUnit> PickNextTarget(IEnumerable<IUnit> candidateTargets)
        {
            IList<IUnit> targets = new List<IUnit>();

            IEnumerable<IUnit> sortedTargets = candidateTargets.
                OrderBy(t => t.HealthPoints).
                ThenBy(t => t.Name);

            try
            {
                targets.Add(sortedTargets.ElementAt(0));
            }
            catch (Exception)
            {
                //skip
            }

            return targets;
        }
    }
}
