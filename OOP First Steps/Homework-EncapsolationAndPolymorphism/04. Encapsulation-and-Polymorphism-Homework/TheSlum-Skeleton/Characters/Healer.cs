namespace TheSlum.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    public class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, Team team, 
            int range = 6, int healthPoints = 75, int defensePoints = 50, int healingPoints = 60)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }

        public int HealingPoints { get; set; }

        public override void AddToInventory(Item item)
        {
            Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.OrderBy(ch => ch.HealthPoints)
                .Where(ch => ch.Team == this.Team)
                .Where(ch => ch.Id != this.Id)
                .Where(ch => ch.IsAlive == true)
                .FirstOrDefault();
        }



        public override string ToString()
        {
            return string.Format("{0}, Healing: {1}", base.ToString(), this.HealingPoints);
        }
    }
}
