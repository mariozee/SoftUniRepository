namespace WinterIsComing.Models.Units
{
    using System;
    using Interfaces;
    using Core.Exceptions;
    using Core;
    using System.Text;

    public abstract class Unit : IUnit
    {
        private const int MinRange = 0;
        private const int MinHealthPoints = 0;
        private const int MinAttackPoints = 0;
        private const int MinEnergyPoints = 0;

        private string name;
        private int attackPoints;
        private int healthPoints;
        private int energyPoints;
        private int defensePoints;
        private int range;
        private int x;
        private int y;        

        protected Unit(int attackPoints, int healthPoints, int energyPoints, int defensePoints, int range, string name, int x, int y)
        {
            this.attackPoints = attackPoints;
            this.healthPoints = healthPoints;
            this.energyPoints = energyPoints;
            this.defensePoints = defensePoints;
            this.range = range;
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public ICombatHandler CombatHandler { get; protected set; }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                if (value < MinAttackPoints)
                {
                    value = MinAttackPoints;
                }

                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            private set
            {
                this.defensePoints = value;
            }
        }        
       
        public int EnergyPoints
        {
            get
            {
                return this.energyPoints;
            }
            set
            {
                if (value < MinEnergyPoints)
                {
                    value = MinEnergyPoints;
                }

                this.energyPoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value < MinHealthPoints)
                {
                    value = MinHealthPoints;
                }

                this.healthPoints = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //TODO: throw
                }

                this.name = value;
            }
        }

        public int Range
        {
            get
            {
                return this.range;
            }
            private set
            {
                if (value < MinRange)
                {
                    //TODO: throw
                    this.range = value;
                }
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($">{this.Name} - {this.GetType().Name} at ({this.X},{this.Y})");
            if (this.HealthPoints <= 0)
            {
                sb.Append("(Dead)");
            }
            else
            {
                sb.AppendLine($"-Health points = {this.HealthPoints}");
                sb.AppendLine($"-Attack points = {this.AttackPoints}"); 
                sb.AppendLine($"-Defense points = {this.DefensePoints}");
                sb.AppendLine($"-Energy points = {this.EnergyPoints}");
                sb.Append($"-Range = {this.Range}");
            }

            return sb.ToString();
        }   
    }
}
