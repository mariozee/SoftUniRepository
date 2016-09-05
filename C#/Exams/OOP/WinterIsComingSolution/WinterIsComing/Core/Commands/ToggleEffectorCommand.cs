namespace WinterIsComing.Core.Commands
{
    using WinterIsComing.Interfaces;

    public class ToggleEffectorCommand : Command
    {
        public ToggleEffectorCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            this.Engine.Effector.ApplyEffect(this.Engine.Units);
        }
    }
}
