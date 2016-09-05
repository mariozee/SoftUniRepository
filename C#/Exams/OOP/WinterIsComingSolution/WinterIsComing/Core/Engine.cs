namespace WinterIsComing.Core
{
    using System;
    using Interfaces;
    using System.Collections.Generic;
    using Exceptions;

    public class Engine : IEngine
    {
        private IInputReader reader;
        private IOutputWriter writer;
        private IUnitContainer unitsContainer;
        private ICommandDispatcher dispatcher;
        private IUnitEffector effector;
        private ICollection<IUnit> units;
        private bool isRunning;
        
        public Engine(
            IInputReader reader,
            IOutputWriter writer,
            IUnitContainer unitsContainer,
            ICommandDispatcher dispatcher,
            IUnitEffector effector)
        {
            this.units = new LinkedList<IUnit>();
            this.reader = reader;
            this.writer = writer;
            this.unitsContainer = unitsContainer;   
            this.dispatcher = dispatcher;
            this.dispatcher.Engine = this;
            this.effector = effector;
        }

        public ICollection<IUnit> Units { get { return this.units; } }
        
        public IInputReader Reader { get { return this.reader; } }

        public IOutputWriter Writer { get { return this.writer; } }

        public IUnitContainer UnitContainer { get { return this.unitsContainer; } }

        public IUnitEffector Effector { get { return this.effector; } }

        public void Run()
        {
            this.isRunning = true;
            this.dispatcher.SeedCommands();

            while (isRunning)
            {
                string[] inputArgs = this.Reader.ReadLine().Split();
                try
                {
                    this.dispatcher.DispatchCommand(inputArgs);
                }
                catch (GameException)
                {
                }
                
            }
        }

        public void Stop()
        {
            this.isRunning = false;
        }

        public void AddUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new GameException(GlobalMessages.CantBeNull);
            }

            this.units.Add(unit);
        }

        public void RemoveUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new GameException(GlobalMessages.CantBeNull);
            }

            this.units.Remove(unit);
        }
    }
}
