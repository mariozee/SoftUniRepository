using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Interfaces;

namespace WinterIsComingMain.Models
{
    public abstract class AbstractUnit : IUnit
    {
        private ICombatHandler combatHandler;
        private string name;
        private int range;

        public AbstractUnit(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public int AttackPoints { get; set; }
        
        public ICombatHandler CombatHandler
        {
            get
            {
                return this.combatHandler;
            }
            protected set
            {
                this.combatHandler = value;
            }
        }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public int HealthPoints { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }

        public int Range
        {
            get
            {
                return this.range;
            }
            protected set
            {
                this.range = value;
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            if (this.HealthPoints > 0)
            {
                output.AppendFormat(">{0} - {1} at ({2},{3}){4}",
                this.Name,
                this.GetType().Name,
                this.X,
                this.Y,
                Environment.NewLine);

                output.AppendFormat("-Health points = {0}{1}", this.HealthPoints, Environment.NewLine);
                output.AppendFormat("-Attack points = {0}{1}", this.AttackPoints, Environment.NewLine);
                output.AppendFormat("-Defense points = {0}{1}", this.DefensePoints, Environment.NewLine);
                output.AppendFormat("-Energy points = {0}{1}", this.EnergyPoints, Environment.NewLine);
                output.AppendFormat("-Range = {0}", this.Range, Environment.NewLine);
            }
            else
            {
                output.AppendFormat(">{0} - {1} at ({2},{3}){4}",
                this.Name,
                this.GetType().Name,
                this.X,
                this.Y,
                Environment.NewLine);

                output.Append("(Dead)");
            }

            return output.ToString();
        }
    }
}
