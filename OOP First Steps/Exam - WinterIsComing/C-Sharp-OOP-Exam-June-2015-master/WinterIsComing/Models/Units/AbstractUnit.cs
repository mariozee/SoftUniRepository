using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public class AbstractUnit : IUnit
    {
        private ICombatHandler _combatHandler;
        private string _name;
        private int _range;

        public AbstractUnit(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name 
        {
            get
            {
                return this._name;
            }
            protected set
            {
                this._name = value;
            }
        }

        public int Range 
        {
            get
            {
                return this._range;
            }
            protected set
            {
                this._range = value;
            }
        }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler 
        {
            get
            {
                return this._combatHandler;
            }
            protected set
            {
                this._combatHandler = value;
            }
        }

        public override string ToString()
        {
            string str;
            if (this.HealthPoints <= 0)
            {
                str = "(Dead)";
            }
            else
            {
                str = string.Format("-Health points = {0}\n" +
                                 "-Attack points = {1}\n" +
                                 "-Defense points = {2}\n" +
                                 "-Energy points = {3}\n" +
                                 "-Range = {4}",
                                 this.HealthPoints,
                                 this.AttackPoints,
                                 this.DefensePoints,
                                 this.EnergyPoints,
                                 this.Range);
            }
            return str;
        }
    }
}
