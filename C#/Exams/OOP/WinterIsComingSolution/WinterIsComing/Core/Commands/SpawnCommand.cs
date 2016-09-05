namespace WinterIsComing.Core.Commands
{
    using System;
    using Enums;
    using Interfaces;

    public class SpawnCommand : Command
    {
        public SpawnCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            UnitType type = (UnitType) Enum.Parse(typeof(UnitType), commandArgs[1]);
            string name = commandArgs[2];
            int x = int.Parse(commandArgs[3]);
            int y = int.Parse(commandArgs[4]);

            var unit = UnitFactory.CreateUnit(type, name, x, y);

            this.Engine.AddUnit(unit);
            this.Engine.UnitContainer.Add(unit);

            this.Engine.Writer.WriteLine($"{name} has spawned");
        }
    }
}
