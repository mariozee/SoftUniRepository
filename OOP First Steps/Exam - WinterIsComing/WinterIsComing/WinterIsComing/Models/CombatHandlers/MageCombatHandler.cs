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
    public class MageCombatHandler : CombatHandler
    {
        public MageCombatHandler()
        {
            this.IsThisSpellUsed = false;
        }

        public bool IsThisSpellUsed { get; private set; }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            IList<IUnit> mageTargets = new List<IUnit>();

            var orderByHealthAndName = candidateTargets.
                OrderByDescending(t => t.HealthPoints).
                ThenBy(t => t.Name);

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    mageTargets.Add(orderByHealthAndName.ElementAt(i));
                }
            }
            catch (Exception)
            {
                //skip
            }

            return mageTargets;
        }

        public override ISpell GenerateAttack()
        {
            if (!this.IsThisSpellUsed)
            {
                int spellDamage = this.Unit.AttackPoints;
                FireBreath FireBreath = new FireBreath(spellDamage);

                if (this.Unit.EnergyPoints < FireBreath.EnergyCost)
                {
                    string message = string.Format("{0} does not have enough energy to cast {1}",
                        this.Unit.Name,
                        FireBreath.GetType().Name);

                    throw new NotEnoughEnergyException(message);
                }

                this.IsThisSpellUsed = true;

                this.Unit.EnergyPoints -= FireBreath.EnergyCost;

                return FireBreath;
            }
            else
            {
                int spellDamage = this.Unit.AttackPoints * 2;
                Blizzard Blizzard = new Blizzard(spellDamage);

                if (Unit.EnergyPoints < Blizzard.EnergyCost)
                {
                    string message = string.Format("{0} does not have enough energy to cast {1}",
                        this.Unit.Name,
                        Blizzard.GetType().Name);

                    throw new NotEnoughEnergyException(message);
                }

                this.IsThisSpellUsed = false;

                this.Unit.EnergyPoints -= Blizzard.EnergyCost;

                return Blizzard;
            }
        }

    }
}
