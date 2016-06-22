namespace WinterIsComingMain.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Exceptions;

    class FightCommand : AbstractCommand
    {
        public FightCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var killedUnits = new List<IUnit>();

            foreach (var currentUnit in this.Engine.Units)
            {
                if (currentUnit.HealthPoints <= 0)
                {
                    continue;
                }

                var unitsInRange = this.Engine.UnitContainer
                    .GetUnitsInRange(currentUnit.X, currentUnit.Y, currentUnit.Range)
                    .Where(u => u.HealthPoints > 0 && u != currentUnit);

                var targets = currentUnit.CombatHandler.PickNextTarget(unitsInRange);

                try
                {
                    this.ProcessBattle(currentUnit, targets, killedUnits);
                }
                catch (NotEnoughtEnergyException ex)
                {
                    this.Engine.OutputWriter.Write(ex.Message);
                }
            }

            foreach (var killedUnit in killedUnits)
            {
                this.Engine.UnitContainer.Remove(killedUnit);
            }
        }

        private void ProcessBattle(IUnit currentUnit, IEnumerable<IUnit> targets, IList<IUnit> killedUnits)
        {
            foreach (var target in targets)
            {
                var attack = currentUnit.CombatHandler.GenerateAttack();

                int healthDamage = attack.Damge - target.DefensePoints;
                if (healthDamage > 0)
                {
                    target.HealthPoints -= healthDamage;

                    this.Engine.OutputWriter.Write(string.Format(
                        "{0} case {1} on {2} for {3} damage",
                        currentUnit.Name,
                        attack.GetType().Name,
                        target.Name,
                        healthDamage));
                }

                if (target.HealthPoints < 0)
                {
                    target.HealthPoints = 0;

                    this.Engine.OutputWriter.Write(string.Format(
                        "{0} has killed {1}",
                        currentUnit.Name,
                        target.Name));

                    killedUnits.Add(target);
                }
            }
        }
    }
}