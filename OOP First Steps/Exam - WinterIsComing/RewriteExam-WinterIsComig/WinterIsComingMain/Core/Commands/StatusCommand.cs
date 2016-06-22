namespace WinterIsComingMain.Core.Commands
{
    using System.Linq;
    using Interfaces;

    public class StatusCommand : AbstractCommand
    {
        public StatusCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string unitName = commandArgs[1];

            var unit = this.Engine.Units
                .First(u => u.Name == unitName);

            this.Engine.OutputWriter.Write(unit.ToString());
        }
    }
}
