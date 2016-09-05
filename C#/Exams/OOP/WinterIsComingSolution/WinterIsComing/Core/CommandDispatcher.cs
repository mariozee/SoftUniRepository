namespace WinterIsComing.Core
{
    using Interfaces;
    using System.Collections.Generic;
    using System;
    using Commands;
    using Exceptions;
    using System.Reflection;
    using System.Linq;

    public class CommandDispatcher : ICommandDispatcher
    {
        private IDictionary<string, ICommand> commands;

        public CommandDispatcher()
        {
            commands = new Dictionary<string, ICommand>();
        }

        public IEngine Engine { get; set; }

        public void DispatchCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0];
            if (!this.commands.ContainsKey(commandName))
            {
                throw new GameException(GlobalMessages.NotSupportedCommand);
            }            

            this.commands[commandName].Execute(commandArgs);
        }

        public void SeedCommands()
        {
            this.commands.Add("spawn", new SpawnCommand(this.Engine));
            this.commands.Add("fight", new FightCommand(this.Engine));
            this.commands.Add("move", new MoveCommand(this.Engine));
            this.commands.Add("status", new StatusCommand(this.Engine));
            this.commands.Add("toggle-effector", new ToggleEffectorCommand(this.Engine));
            this.commands.Add("winter-came", new WinterCameCommand(this.Engine));
        }
    }
}
