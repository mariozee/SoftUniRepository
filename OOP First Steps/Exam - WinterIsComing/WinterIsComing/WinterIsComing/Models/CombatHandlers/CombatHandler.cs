using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.CombatHandlers
{
    public abstract class CombatHandler : ICombatHandler
    {
        public IUnit Unit { get; set; }

        public abstract ISpell GenerateAttack();

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);
    }
}
