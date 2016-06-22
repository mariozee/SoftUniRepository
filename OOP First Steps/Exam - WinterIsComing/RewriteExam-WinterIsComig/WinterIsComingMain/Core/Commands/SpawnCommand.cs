
namespace WinterIsComingMain.Core.Commands
{
    using System;
    using Interfaces;

    public class SpawnCommand : AbstractCommand
    {
        public SpawnCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            EnumUnitType unitType = (EnumUnitType)Enum.Parse(
                typeof(EnumUnitType), commandArgs[1]);
            string unitName = commandArgs[2];
            int x = int.Parse(commandArgs[3]);
            int y = int.Parse(commandArgs[4]);

            var unit = UnitFactory.Create(unitType, unitName, x, y);

            this.Engine.InsertUnit(unit);
            this.Engine.UnitContainer.Add(unit);
            this.Engine.OutputWriter.Write(string.Format(
                GlobalMessages.UnitsSpawned, unitName));
        }
    }
}
