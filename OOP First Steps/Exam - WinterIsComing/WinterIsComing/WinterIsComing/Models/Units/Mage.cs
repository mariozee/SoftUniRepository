using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Mage : Units
    {
        public Mage(string name, int x, int y)
            : base(name, x, y)
        {
            this.Range = 2;
            this.AttackPoints = 80;
            this.HealthPoints = 80;
            this.DefensePoints = 40;
            this.EnergyPoints = 120;
            this.CombatHandler = new MageCombatHandler();
            this.CombatHandler.Unit = this;
        }
    }
}
