using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Interfaces
{
    public interface ICombatHandler
    {
        IUnit Unit { get; set; }

        IEnumerable<IUnit> PickNextTarget(IEnumerable<IUnit> candidateTargets);

        ISpell GenerateAttack();
    }
}
