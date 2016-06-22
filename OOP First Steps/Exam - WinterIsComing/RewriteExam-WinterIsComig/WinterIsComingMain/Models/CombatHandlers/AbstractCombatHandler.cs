using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Interfaces;

namespace WinterIsComingMain.Models.CombatHandlers
{
    public abstract class AbstractCombatHandler : ICombatHandler
    {
        public IUnit Unit { get; set; }

        public abstract ISpell GenerateAttack();
        
        public abstract IEnumerable<IUnit> PickNextTarget(IEnumerable<IUnit> candidateTargets);
    }
}
