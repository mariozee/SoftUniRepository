namespace WinterIsComingMain.Core.Commands
{
    using Interfaces;

    public abstract class AbstractCommand : ICommand
    {
        public AbstractCommand(IEngine engine)
        {
            this.Engine = engine;
        }

        public IEngine Engine { get; private set; }

        public abstract void Execute(string[] commandArgs);
    }
}