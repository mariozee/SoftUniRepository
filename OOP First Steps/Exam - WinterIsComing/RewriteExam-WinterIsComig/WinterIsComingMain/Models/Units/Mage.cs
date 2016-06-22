using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Models.CombatHandlers;

namespace WinterIsComingMain.Models.Units
{
    public class Mage : AbstractUnit
    {
        private const int DefaultMageRange = 2;
        private const int DefaultMageAttackPoints = 80;
        private const int DefaultMageHealthPoints = 80;
        private const int DefaultMageDefensePoints = 40;
        private const int DefaultMageEnergyPoints = 120;

        public Mage(string name, int x, int y) 
            : base(name, x, y)
        {
            this.Range = DefaultMageRange;
            this.AttackPoints = DefaultMageAttackPoints;
            this.HealthPoints = DefaultMageHealthPoints;
            this.DefensePoints = DefaultMageDefensePoints;
            this.EnergyPoints = DefaultMageEnergyPoints;
            this.CombatHandler = new MageCombatHandler();
            this.CombatHandler.Unit = this;
        }
    }
}
