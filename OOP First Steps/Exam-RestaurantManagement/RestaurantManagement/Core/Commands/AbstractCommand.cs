namespace RestaurantManagement.Core.Commands
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class AbstractCommand : ICommand
    {
        public AbstractCommand(IEnigne engine)
        {
            this.Engine = engine;
        }

        public IEnigne Engine { get; }

        public abstract void Execute(string[] commandArgs);
    }
}
