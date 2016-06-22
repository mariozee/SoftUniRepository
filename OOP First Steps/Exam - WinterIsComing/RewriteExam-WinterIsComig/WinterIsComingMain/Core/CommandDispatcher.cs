using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Core.Commands;
using WinterIsComingMain.Interfaces;

namespace WinterIsComingMain.Core
{
    public class CommandDispatcher : ICommandDispatcher
    {
        protected readonly IDictionary<string, ICommand> commandsByName;

        public CommandDispatcher()
        {
            this.commandsByName = new Dictionary<string, ICommand>();
        }

        public IEngine Engine { get; set; }

        public void DispatchCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0];
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(
                    "Command is not supported by engine");
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public void SeedCommands()
        {
            this.commandsByName["spawn"] = new SpawnCommand(this.Engine);
            this.commandsByName["fight"] = new FightCommand(this.Engine);
            this.commandsByName["move"] = new MoveCommand(this.Engine);
            this.commandsByName["status"] = new StatusCommand(this.Engine);
            this.commandsByName["winter-came"] = new WinterCameCommand(this.Engine);
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
        }
    }
}
