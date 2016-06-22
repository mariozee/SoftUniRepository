using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Interfaces
{
    public interface IUnit
    {
        int X { get; set; }

        int Y { get; set; }

        string Name { get; }

        int Range { get; }

        int AttackPoints { get; set; }

        int HealthPoints { get; set; }

        int DefensePoints { get; set; }

        int EnergyPoints { get; set; }

        ICombatHandler CombatHandler { get; }
    }
}
