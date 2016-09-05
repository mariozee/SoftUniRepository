namespace Blobs.Engine
{
    using System.Collections.Generic;
    using Interfaces;
    using System.Linq;
    using Factories;
    using System;

    public sealed class BlobsEngine : IEngine
    {
        private static IEngine instance;
        private IRenderer render;
        private IDictionary<string, IBlob> blobs;
        private IAttackFactory attackFactory;
        private IBehaviorFactory behaviorFactory;
        private IBlobFactory blobFacotry;
        ICollection<string> outputArgs;

        private BlobsEngine()
        {
            this.render = new ConsoleRenderer();
            this.blobs = new Dictionary<string, IBlob>();
            this.attackFactory = new AttackFactory();
            this.behaviorFactory = new BehaviorFactory();
            this.blobFacotry = new BlobFactory();
            this.outputArgs = new List<string>();
        }

        public static IEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BlobsEngine();
                }

                return instance;
            }
        }

        public void Run()
        {
            ICollection<string> commands = new List<string>();
            foreach (var command in this.render.Input())
            {
                commands.Add(command);
            }

            ICollection<IList<string>> commandsArgs = CommandInterpreter(commands);
            var output = CommandExecuter(commandsArgs);
            render.Ouptut(output);
        }

        private ICollection<string> CommandExecuter(ICollection<IList<string>> commandsArgs)
        {
            foreach (var command in commandsArgs)
            {
                string action = command[0];

                switch (action)
                {
                    case "attack":
                        ProduceAttack(command);
                        break;
                    case "status":
                        blobs.Values.ToList().ForEach(b => outputArgs.Add(b.ToString()));
                        break;
                    case "create":
                        IAttack attack = CreateAttack(command);
                        IBehavior behavior = CreateBehavior(command);
                        IBlob blob = CreateBlob(command, attack, behavior);
                        blobs.Add(blob.Name, blob);
                        break;
                    default:
                        break;
                }

                blobs.Values.ToList().ForEach(b => b.Update());
            }

            return outputArgs;
        }

        private void ProduceAttack(IList<string> command)
        {
            var attackerBlob = blobs.Values.FirstOrDefault(b => b.Name == command[1]);
            var attackedBlob = blobs.Values.FirstOrDefault(b => b.Name == command[2]);

            attackedBlob.Health -= attackerBlob.Attack();
        }

        private IBlob CreateBlob(IList<string> command, IAttack attack, IBehavior behavior)
        {
            string name = command[1];
            int health = int.Parse(command[2]);
            int damage = int.Parse(command[3]);

            var blob = blobFacotry.CreateBlob(name, health, damage, attack, behavior);

            blob.OnBlobDeath += this.PrintBlobDeath;
            blob.OnToggleBehavior += this.PrintBehaviorTriggered;

            return blob;
        }

        private IBehavior CreateBehavior(IList<string> command)
        {
            string behaviorType = command[4];
            var behavior = behaviorFactory.CreateBehavior(behaviorType);

            return behavior;
        }

        private IAttack CreateAttack(IList<string> command)
        {
            string attackType = command[5];
            var attack = attackFactory.CreateAttack(attackType);

            return attack;
        }

        private ICollection<IList<string>> CommandInterpreter(IEnumerable<string> commands)
        {
            ICollection<IList<string>> commandArgs = new List<IList<string>>();
            foreach (var command in commands)
            {
                commandArgs.Add(command.Split().ToList());
            }

            return commandArgs;
        }

        private void PrintBlobDeath(IBlob sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Blob {sender.Name} was KILLED");
        }

        private void PrintBehaviorTriggered(IBlob sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Blob {sender.Name} toggled {sender.Behave.ToString().Substring(23)} behavior");
        }
    }
}