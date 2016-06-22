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
    public class MageCombatHandler : AbstractCombatHandler
    {
        private int flag;

        public MageCombatHandler()
        {
            this.flag = 0;
        }

        public override ISpell GenerateAttack()
        {
            if (this.flag == 0)
            {
                return FireBreath();
            }
            else
            {
                return Blizzard();
            }
        }

        private ISpell Blizzard()
        {
            int damage = this.Unit.AttackPoints * 2;
            ISpell spell = new Blizzard(damage);

            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughtEnergyException(this.Unit.Name +
                    " does not have enogh energy to cast Blizzard.");
            }
            else
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
                this.flag = 0;

                return spell;
            }
        }

        private ISpell FireBreath()
        {
            int damage = this.Unit.AttackPoints;
            ISpell spell = new FireBreath(damage);

            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughtEnergyException(this.Unit.Name +
                    " does not have enogh energy to cast FireBreath.");
            }
            else
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
                this.flag = 1;

                return spell;
            }
        }

        public override IEnumerable<IUnit> PickNextTarget(IEnumerable<IUnit> candidateTargets)
        {
            IList<IUnit> targets = new List<IUnit>();

            IList<IUnit> sortedTargets = candidateTargets.
                OrderByDescending(t => t.HealthPoints).
                ThenBy(t => t.Name).
                ToList();

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    targets.Add(sortedTargets.ElementAt(i));
                }
                catch (Exception)
                {
                    //skip
                }
            }

            return targets;
        }
    }
}
