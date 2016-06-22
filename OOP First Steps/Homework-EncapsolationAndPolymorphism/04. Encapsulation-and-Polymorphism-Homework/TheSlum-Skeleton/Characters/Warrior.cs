namespace TheSlum.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    public class Warrior : Character, IAttack
    {
        public Warrior(string id, int x, int y, Team team, 
            int range = 2, int healthPoints = 200, int defensePoints = 100, int attackPonts = 150)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPonts;
        }

        public int AttackPoints { get; set; }

        public override void AddToInventory(Item item)
        {
            Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.Where(x => x.Team != this.Team)
                .Where(x => x.IsAlive == true).FirstOrDefault();
        }

        public override void RemoveFromInventory(Item item)
        {
            Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            this.AttackPoints += item.AttackEffect; 
            base.ApplyItemEffects(item);
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.AttackPoints -= item.AttackEffect;
            base.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return string.Format("{0}, Attack: {1}", base.ToString(), this.AttackPoints);
        }
    }
}
