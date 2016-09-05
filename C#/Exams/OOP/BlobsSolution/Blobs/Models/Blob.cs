namespace Blobs.Models
{
    using System;
    using Interfaces;

    public class Blob : IBlob
    {
        private IAttack attack;        
        private int health;
        private int turn;


        public Blob(string name, int health, int damage, IAttack attackType, IBehavior behaviorType)
        {
            this.Name = name;
            this.InitialHealth = health;
            this.InitialDamamge = damage;
            this.Damage = damage;
            this.Health = health;
            this.attack = attackType;
            this.Behave = behaviorType;
        }

        public IBehavior Behave { get; private set; }

        public int Damage { get; set; }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.health = value;

                if (!this.IsAlive())
                {
                    if (this.OnBlobDeath != null)
                    {
                        this.OnBlobDeath.Invoke(this, EventArgs.Empty);
                    }

                }
            }
        }
        public int InitialDamamge { get; private set; }

        public int InitialHealth { get; private set; }

        public bool HasBehaved { get; private set; }

        public string Name { get; private set; }

        public int Attack()
        {
            this.attack.ModifyStats(this);



            if (this.ShouldBehave())
            {
                if (!this.HasBehaved)
                {
                    this.TriggerBeahavior();
                    this.HasBehaved = true;
                }
            }

            return this.Damage;// + this.attack.BonusAttack;
        }

        private bool ShouldBehave()
        {
            return this.Health <= (this.InitialHealth / 2);
        }

        public bool IsAlive()
        {
            if (this.Health > 0)
            {
                return true;
            }

            return false;
        }

        private void TriggerBeahavior()
        {
            this.Behave.Behave(this);

            if (this.OnToggleBehavior != null)
            {
                this.OnToggleBehavior.Invoke(this, EventArgs.Empty);
            }
        }

        public void Update()
        {
            if (this.ShouldBehave() || this.HasBehaved)
            {
                if (HasBehaved && turn >= 1)
                {
                    this.Behave.Update(this);
                }
                else if (!this.HasBehaved)
                {
                    TriggerBeahavior();
                    this.HasBehaved = true;
                }

                this.turn++;
            }
        }

        public override string ToString()
        {
            string output = string.Empty;
            if (this.Health <= 0)
            {
                output = $"Blob { this.Name} KILLED";            
            }
            else
            {
                output = $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
            }            

            return output;
        }

        public event OnToggleBehaviorEventHandler OnToggleBehavior;

        public event OnBlobDeathEventHandler OnBlobDeath;
    }
}