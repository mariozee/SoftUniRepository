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
    public class IceGiantCombatHandler : AbstractCombatHandler
    {
        public IceGiantCombatHandler()
            : base()
        {

        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                List<IUnit> targets = new List<IUnit>();
                try
                {
                    targets.Add(candidateTargets.ElementAt(0));
                }
                catch (ArgumentOutOfRangeException)
                {
                    //skip
                }

                return targets;
            }
            else
            {
                return candidateTargets;
            }
        }

        public override ISpell GenerateAttack()
        {
            int damage = this.Unit.AttackPoints;
            
            ISpell spell = new Stomp(damage);
            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(this.Unit.Name + " does not have enough energy to cast Stomp");
            }
            else
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
                this.Unit.AttackPoints += 5;
            }

            return spell;
        }
    }
}
