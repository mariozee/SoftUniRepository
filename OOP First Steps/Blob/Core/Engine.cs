using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Blob.EventArgs;
using Blob.Interfaces;

namespace Blob.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<IBlob> allBlobs = new List<IBlob>();

        private readonly IInputReader inputReader;
        private readonly IOutputWriter outputWriter;

        private IDictionary<string, Action<string[]>> supportedCommands = new Dictionary<string, Action<string[]>>();

        private bool isRunning = false;
        private bool reportEvents = false;
        public Engine(IInputReader inputReader, IOutputWriter outputWriter)
        {
            this.inputReader = inputReader;
            this.outputWriter = outputWriter;
        }
        public void Run()
        {
            isRunning = true;

            DispatchCommands();

            while (isRunning)
            {
                string input = inputReader.Readline();

                ExecuteCommands(input);
            }
        }

        private void DispatchCommands()
        {
            this.supportedCommands.Add("create", CreateCommand);
            this.supportedCommands.Add("attack", AttackCommand);
            this.supportedCommands.Add("pass", PassCommand);
            this.supportedCommands.Add("status", StatusCommand);
            this.supportedCommands.Add("drop", DropCommand);
            this.supportedCommands.Add("report-events", ReportEventsCommand);

        }
        private void ExecuteCommands(string input)
        {
            var inputParams = input.Split(new char[] {}, StringSplitOptions.RemoveEmptyEntries);

            var commandAlias = inputParams[0];
            var commandArgs = inputParams.Skip(1).ToArray();

            if (!supportedCommands.ContainsKey(commandAlias))
                throw new NotImplementedException();

            supportedCommands[inputParams[0]](commandArgs);
            
            UpdateBlobs();
          
        }
        protected virtual void OnBlobDeath(object sender, BlobEventArgs args)
        {
            if (reportEvents)
                outputWriter.AppendLine(string.Format(EngineMessages.OnBlobDeath, args.Blob.Name));
        }
        protected virtual void OnBehaviorChange(object sender, BlobEventArgs args)
        {
            if (reportEvents)
                outputWriter.AppendLine(string.Format(EngineMessages.OnBehaviorChange, args.Blob.Name, args.Blob.Behavior.GetType().Name));
        }
        private void ReportEventsCommand(string[] args)
        {
            this.reportEvents = true;
        }
        private void UpdateBlobs()
        {
            this.allBlobs
                .ToList()
                .ForEach(b =>
                {
                    b.Update();
                });
        }
        private void DropCommand(string[] commandArgs)
        {
            isRunning = false;
        }
        private void StatusCommand(string[] commandArgs)
        {
            this.allBlobs
                .ToList()
                .ForEach(b =>
                {
                    outputWriter.AppendLine(b.ToString());
                });
        }
        private void PassCommand(string[] commandArgs)
        {
            //...
        }

        private void AttackCommand(string[] commandArgs)
        {
            string attackerName = commandArgs[0];
            string defenderName = commandArgs[1];

            if (attackerName.Equals(defenderName))
                throw new InvalidOperationException(EngineMessages.CannotAttackItself);

            var attacker = GetBlob(attackerName);
            var defender = GetBlob(defenderName);

            if (attacker.Health == 0)
                throw new InvalidOperationException(EngineMessages.CannotAttackWithDeadBlob);

            if (defender.Health == 0)
                throw new InvalidOperationException(EngineMessages.CannotAttackDeadBlob);

            var attack = attacker.ProduceAttack();

            defender.AcceptAttack(attack);

        }

        private IBlob GetBlob(string blobName)
        {
            var result = this.allBlobs.FirstOrDefault(b => b.Name.Equals(blobName));

            if (result == null)
                throw new ArgumentException(string.Format(EngineMessages.CannotFindBlobByName, blobName));

            return result;

        }
        private void CreateCommand(string[] commandArgs)
        {
            string blobName = commandArgs[0];
            int blobHealth = int.Parse(commandArgs[1]);
            int blobDamage = int.Parse(commandArgs[2]);
            string blobTypeName = commandArgs[3];
            string blobAttackTypeName = commandArgs[4];

            IBehavior blobBehavior = CreateBehavior(blobTypeName, blobDamage);
            Type blobAttackType = GetAttackType(blobAttackTypeName);

            IBlob blob = new Models.Blob(blobName, blobHealth, blobDamage, blobBehavior, blobAttackType);

            blob.OnBlobDeath += OnBlobDeath;

            this.allBlobs.Add(blob);
        }

        private IBehavior CreateBehavior(string behaviorTypeName, int blobDamage)
        {
            var behaviorType =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name.Contains(behaviorTypeName) && t.GetInterfaces().Contains(typeof (IBehavior)));

            if (behaviorTypeName == null)
                throw new NotImplementedException(string.Format(EngineMessages.NotImplemented, "Behavior \"" + behaviorTypeName + "\""));

            IBehavior behavior = (IBehavior)Activator.CreateInstance(behaviorType, blobDamage);

            behavior.OnBehaviorToggleEventHandler += OnBehaviorChange;

            return behavior;
        }

        private Type GetAttackType(string attackTypeName)
        {
            var attackType =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name.Contains(attackTypeName) && t.GetInterfaces().Contains(typeof (IAttack)));

            if (attackType == null)
                throw new NotImplementedException(string.Format(EngineMessages.NotImplemented, "AttackType \"" + attackTypeName + "\""));

            return attackType;
        }
    }
}
