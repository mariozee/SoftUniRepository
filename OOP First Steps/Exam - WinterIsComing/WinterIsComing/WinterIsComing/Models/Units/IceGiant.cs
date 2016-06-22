using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class IceGiant : Units
    {
        public IceGiant(string name, int x, int y)
            : base(name, x, y)
        {
            this.Range = 1;
            this.AttackPoints = 150;
            this.HealthPoints = 300;
            this.DefensePoints = 60;
            this.EnergyPoints = 50;
            this.CombatHandler = new IceGiantCombatHandler();
            this.CombatHandler.Unit = this;
        }
    }
}
