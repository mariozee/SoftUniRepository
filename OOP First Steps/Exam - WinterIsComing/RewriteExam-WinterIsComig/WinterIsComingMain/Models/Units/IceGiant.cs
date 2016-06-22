using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Models.CombatHandlers;

namespace WinterIsComingMain.Models.Units
{
    public class IceGiant : AbstractUnit
    {
        private const int DefaultIceGiantRange = 1;
        private const int DefaultIceGiantAttackPoints = 150;
        private const int DefaultIceGiantHealthPoints = 300;
        private const int DefaultIceGiantDefensePoints = 60;
        private const int DefaultIceGiantEnergyPoints = 50;

        public IceGiant(string name, int x, int y)
            : base(name, x, y)
        {
            this.Range = DefaultIceGiantRange;
            this.AttackPoints = DefaultIceGiantAttackPoints;
            this.HealthPoints = DefaultIceGiantHealthPoints;
            this.DefensePoints = DefaultIceGiantDefensePoints;
            this.EnergyPoints = DefaultIceGiantEnergyPoints;
            this.CombatHandler = new IceGiantCombatHandler();
            this.CombatHandler.Unit = this;            
        }
    }
}
