namespace WinterIsComing.Core.Commands
{
    using System;
    using Interfaces;

    public abstract class Command : ICommand
    {
        protected Command(IEngine engine)
        {
            this.Engine = engine;
        }

        public IEngine Engine { get; }

        public abstract void Execute(string[] commandArgs);
    }
}
