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
    public class MageCombatHandler : AbstractCombatHandler
    {
        private int _flag;

        public MageCombatHandler()
            : base()
        {
            this._flag = 0;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            List<IUnit> targets = new List<IUnit>();

            List<IUnit> sortedByMostHealthAndName = candidateTargets.OrderByDescending(x => x.HealthPoints).ThenBy(x => x.Name).ToList();            
            
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    targets.Add(sortedByMostHealthAndName.ElementAt(i));
                }
                catch (ArgumentOutOfRangeException)
                {
                    //skip
                }
            }

            return targets;
        }

        public override ISpell GenerateAttack()
        {
            if (this._flag == 0)
            {
                return this.FireBreath();
            }
            else
            {
                return this.Blizzard();
            }
        }

        public ISpell FireBreath()
        {
            int damage = this.Unit.AttackPoints;
            ISpell spell = new FireBreath(damage);
            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(this.Unit.Name + " does not have enough energy to cast FireBreath");
            }
            else
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
                this._flag = 1;
                return spell;
            }
        }

        public ISpell Blizzard()
        {
            int damage = this.Unit.AttackPoints * 2;
            ISpell spell = new Blizzard(damage);
            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(this.Unit.Name + " does not have enough energy to cast Blizzard");
            }
            else
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
                this._flag = 0;
                return spell;
            }
        }
    }
}
