using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Models.CombatHandlers;

namespace WinterIsComingMain.Models.Units
{
    public class Warrior : AbstractUnit
    {
        private const int DefaultWarriorRange = 1;
        private const int DefaultWarriorAttackPoints = 120;
        private const int DefaultWarriorHealthPoints = 180;
        private const int DefaultWarriorDefensePoints = 70;
        private const int DefaultWarriorEnergyPoints = 60;

        public Warrior(string name, int x, int y) 
            : base(name, x, y)
        {
            this.Range = DefaultWarriorRange;
            this.AttackPoints = DefaultWarriorAttackPoints;
            this.HealthPoints = DefaultWarriorHealthPoints;
            this.DefensePoints = DefaultWarriorDefensePoints;
            this.EnergyPoints = DefaultWarriorEnergyPoints;
            this.CombatHandler = new WarriorCombatHandler();
            this.CombatHandler.Unit = this;
        }
    }
}
