using System;
using Blob.Core;
using Blob.EventArgs;
using Blob.Interfaces;

namespace Blob.Models.Behaviours
{
    public class Behaviour : IBehavior
    {
        public event EventHandler<BlobEventArgs> OnBehaviorToggleEventHandler;

        private const int TurnsBeforeUpdate = 1;

        private int damageBonus;
        private int healthBonus;
        private int damageDescendingRate;
        private int healthDescendingRate;

        private int blobInitialDamage;

        private int elapsedTurns = 0;

        private IBlob blob;

        public Behaviour(int damageBonus, int healthBonus, int damageDescendingRate, int healthDescendingRate, int blobDamage)
        {
            this.CanTriggerBehavior = true;

            if (damageBonus < 0 || healthBonus < 0 || damageDescendingRate < 0 || healthDescendingRate < 0)
                throw new ArgumentOutOfRangeException();

            if (damageDescendingRate > damageBonus || healthDescendingRate > healthBonus)
                throw new ArgumentException();

            this.damageBonus = damageBonus;
            this.healthBonus = healthBonus;
            this.damageDescendingRate = damageDescendingRate;
            this.healthDescendingRate = healthDescendingRate;
            this.blobInitialDamage = blobDamage;
        }

        public void Update()
        {
            if (this.CanTriggerBehavior)
                return;

            elapsedTurns++;

            if (elapsedTurns <= TurnsBeforeUpdate)
                return;

            if (this.blob.Damage > blobInitialDamage)
                this.blob.Damage -= damageDescendingRate;

            this.blob.Health -= healthDescendingRate;
        }

        public bool CanTriggerBehavior
        {
            get; private set;
        }

        public void ApplyEffect(IBlob blob)
        {
            if (blob == null)
                throw new ArgumentNullException("blob");

            if (!CanTriggerBehavior)
                throw new InvalidOperationException(EngineMessages.SameBehaviorToggleErrorMsg);

            this.CanTriggerBehavior = false;

            this.blob = blob;

            blob.Damage += damageBonus;
            blob.Health += healthBonus;

            OnBehaviorToggle();
        }

        protected virtual void OnBehaviorToggle()
        {
            var e = OnBehaviorToggleEventHandler;

            if (e != null)
            {
                e(this, new BlobEventArgs(this.blob));
            }
        }
    }
}
