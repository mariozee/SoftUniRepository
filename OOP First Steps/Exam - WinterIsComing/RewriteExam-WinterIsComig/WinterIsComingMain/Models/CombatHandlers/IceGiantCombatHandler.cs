using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Interfaces;
using WinterIsComingMain.Models.Spells;
using WinterIsComingMain.Exceptions;
using WinterIsComingMain.Core;

namespace WinterIsComingMain.Models.CombatHandlers
{
    public class IceGiantCombatHandler : AbstractCombatHandler
    {
        public override ISpell GenerateAttack()
        {
            int damage = this.Unit.AttackPoints;

            ISpell spell = new Stomp(damage);
            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                string message = string.Format(GlobalMessages.NotEnoughtEnergy, 
                    this.Unit.Name, 
                    spell.GetType().Name);

                throw new NotEnoughtEnergyException(message);
            }
            else
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
                this.Unit.AttackPoints += 5;

                return spell;
            }
        }

        public override IEnumerable<IUnit> PickNextTarget(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                IList<IUnit> targets = new List<IUnit>();
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
    }
}
