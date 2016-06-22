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
    public class WarriorCombatHandler : CombatHandler
    {
        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            IList<IUnit> warriorTargets = new List<IUnit>();

            var orderByHealthAndName = candidateTargets.
                OrderBy(t => t.HealthPoints).
                ThenBy(t => t.Name);

            try
            {
                warriorTargets.Add(orderByHealthAndName.ElementAt(0));
            }
            catch (Exception)
            {
                //skip
            }

            return warriorTargets;
        }

        public override ISpell GenerateAttack()
        {
            int attackDamage = this.Unit.AttackPoints;

            if (Unit.HealthPoints <= 80)
            {
                attackDamage += this.Unit.HealthPoints * 2;
            }

            Cleave Cleave = new Cleave(attackDamage);

            if (Unit.HealthPoints > 50)
            {
                if (Unit.EnergyPoints < Cleave.EnergyCost)
                {
                    string message = string.Format("{0} does not have enough energy to cast {1}",
                        this.Unit.Name,
                        Cleave.GetType().Name);

                    throw new NotEnoughEnergyException(message);
                }

                Unit.EnergyPoints -= Cleave.EnergyCost;
            }

            return Cleave;
        }
    }
}
