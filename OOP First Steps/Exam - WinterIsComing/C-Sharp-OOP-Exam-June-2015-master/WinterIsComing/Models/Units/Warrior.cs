using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Warrior : AbstractUnit
    {
        public Warrior(string name, int x, int y)
            : base(name, x, y)
        {
            this.Range = 1;
            this.AttackPoints = 120;
            this.HealthPoints = 180;
            this.DefensePoints = 70;
            this.EnergyPoints = 60;
            this.CombatHandler = new WarriorCombatHandler();
            this.CombatHandler.Unit = this;
        }

        public override string ToString()
        {
            return string.Format(">{0} - Warrior at ({1},{2})", this.Name, this.X, this.Y) + "\n" + base.ToString();
        }
    }
}
