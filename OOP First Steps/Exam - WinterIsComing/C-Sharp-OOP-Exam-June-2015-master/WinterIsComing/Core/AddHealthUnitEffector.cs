using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Core
{
    public sealed class AddHealthUnitEffector : IUnitEffector
    {
        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (IUnit unit in units)
            {
                if (unit.HealthPoints > 0)
                {
                    unit.HealthPoints += 50;
                }
                
            }
        }
    }
}
