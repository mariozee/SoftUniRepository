namespace WinterIsComing.Core.Commands
{
    using System;
    using WinterIsComing.Interfaces;
    using System.Linq;
    public class MoveCommand : Command
    {
        public MoveCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string name = commandArgs[1];
            int x = int.Parse(commandArgs[2]);
            int y = int.Parse(commandArgs[3]);

            var unit = this.Engine.Units.Where(u => u.Name == name).FirstOrDefault();

            this.Engine.UnitContainer.ChangePosition(unit, y, x);
            this.Engine.Writer.WriteLine($"{name} has moved to ({x},{y})");
        }
    }
}
