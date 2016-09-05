namespace WinterIsComing.Core.Commands
{
    using WinterIsComing.Interfaces;

    public class WinterCameCommand : Command
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
