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
    public class IceGiantCombatHandler : CombatHandler
    {

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            IList<IUnit> target = new List<IUnit>();

            if (this.Unit.HealthPoints <= 150)
            {
                target.Add(candidateTargets.FirstOrDefault());
                return target;
            }
            else
            {
                return candidateTargets;
            }
        }

        public override ISpell GenerateAttack()
        {
            int attackDamage = this.Unit.AttackPoints;
            Stomp Stomp = new Stomp(attackDamage);

            if (this.Unit.EnergyPoints < Stomp.EnergyCost)
            {
                string message = string.Format("{0} does not have enough energy to cast {1}",
                    this.Unit.Name,
                    Stomp.GetType().Name);

                throw new NotEnoughEnergyException(message);
            }

            this.Unit.EnergyPoints -= Stomp.EnergyCost;
            this.Unit.AttackPoints += 5;

            return Stomp;
        }
    }
}
