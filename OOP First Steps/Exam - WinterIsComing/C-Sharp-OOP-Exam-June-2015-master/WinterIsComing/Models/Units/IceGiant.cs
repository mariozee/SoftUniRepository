using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class IceGiant : AbstractUnit
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

        public override string ToString()
        {
            return string.Format(">{0} - IceGiant at ({1},{2})", this.Name, this.X, this.Y) + "\n" + base.ToString();
        }
    }
}
