namespace WinterIsComing.Core
{
    using System;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    class UnitEffector : IUnitEffector
    {
        private const int HealthBonus = 50;

        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            var aliveUnits = units.Where(u => u.HealthPoints > 0);

            foreach (var unit in aliveUnits)
            {
                unit.HealthPoints += HealthBonus;
            }
        }
    }
}
