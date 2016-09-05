namespace WinterIsComing.Core.Commands
{
    using Interfaces;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Exceptions;

    public class FightCommand : Command
    {
        public FightCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var killedUnits = new List<IUnit>();

            foreach (var unit in this.Engine.Units)
            {
                if (unit.HealthPoints <= 0)
                {
                    continue;
                }

                var unitsInRange = this.Engine.UnitContainer.GetUnitsInRange(unit.Y, unit.X, unit.Range);

                var targets = unit.CombatHandler.PickNextTargets(unitsInRange).Where(u => u.HealthPoints > 0);

                try
                {
                    this.ProcessBattle(unit, targets, killedUnits);
                }
                catch (GameException ge)
                {
                    this.Engine.Writer.WriteLine(ge.Message);
                }

            }

            foreach (var killedUnit in killedUnits)
            {
                this.Engine.UnitContainer.Remove(killedUnit);
            }
        }

        private void ProcessBattle(IUnit attacker, IEnumerable<IUnit> targets, List<IUnit> killedUnits)
        {
            foreach (var target in targets)
            {
                var spell = attacker.CombatHandler.GenerateAttack();
                int spellDamage = Math.Max(spell.Damage - target.DefensePoints, 0);
                target.HealthPoints -= spellDamage;

                string attackStatus = $"{attacker.Name} cast {spell.GetType().Name} on {target.Name} for {spellDamage} damage";
                this.Engine.Writer.WriteLine(attackStatus);

                if (target.HealthPoints <= 0)
                {
                    killedUnits.Add(target);
                    this.Engine.Writer.WriteLine($"{attacker.Name} has killed {target.Name}");
                }
            }
        }
    }
}
