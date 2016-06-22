namespace WinterIsComingMain.Core.Commands
{
    using Interfaces;

    public class WinterCameCommand : AbstractCommand
    {
        public WinterCameCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            this.Engine.Stop();
        }
    }
}
