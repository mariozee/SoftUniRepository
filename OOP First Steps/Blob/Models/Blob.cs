using System;
using Blob.Core;
using Blob.EventArgs;
using Blob.Interfaces;

namespace Blob.Models
{
    public class Blob : IBlob
    {
        public event EventHandler<BlobEventArgs> OnBlobDeath = delegate { };

        private static int MinNameLength = 2;

        private readonly int initialHealth;

        private int health;
        private string name;
        private int damage;
        private IBehavior behavior;
        private Type attackType;

        public Blob(string name, int startHealth, int damage, IBehavior behavior, Type attackType)
        {
            this.Name = name;
            this.Health = startHealth;
            this.initialHealth = startHealth;
            this.Damage = damage;
            this.Behavior = behavior;

            if (attackType == null)
                throw new ArgumentNullException("Unkown attack type");

            this.attackType = attackType;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinNameLength)
                    throw new ArgumentException(string.Format(EngineMessages.StringLengthOutOfRange, "Name", MinNameLength));

                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set 
            {
                this.health = value < 0 ? 0 : value;
            }
        }
        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(string.Format(EngineMessages.MustBePositive, "Damage"));

                this.damage = value;
            }
        }

        public IBehavior Behavior
        {
            get { return this.behavior; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException();

                this.behavior = value;
            }
        }

        public void Update()
        {
            behavior.Update();
        }

        public IAttack ProduceAttack()
        {
            var attack = (IAttack)Activator.CreateInstance(attackType, this.damage);

            attack.ApplyEffect(this);

            if (this.Behavior.CanTriggerBehavior && (this.Health <= this.initialHealth / 2))
                this.Behavior.ApplyEffect(this);

            attack.Damage = this.Damage;

            return attack;
        }

        public void AcceptAttack(IAttack attack)
        { 
            this.Health -= attack.Damage;

            if ((this.Health <= this.initialHealth / 2) && behavior.CanTriggerBehavior)
                behavior.ApplyEffect(this);

            if (this.Health == 0)
                OnBlobDeath(this, new BlobEventArgs(this));
        }

        public override string ToString()
        {
            return 
                this.Health > 0 
                ? 
                string.Format(EngineMessages.AliveBlobPrintString, this.Name, this.Health, this.Damage) 
                : 
                string.Format("Blob {0} KILLED", this.Name);
        }
    }
}
