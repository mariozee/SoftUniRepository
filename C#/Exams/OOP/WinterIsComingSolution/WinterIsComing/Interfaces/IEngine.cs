namespace WinterIsComing.Interfaces
{
    using System.Collections.Generic;

    public interface IEngine
    { 
        IInputReader Reader { get; }

        IOutputWriter Writer { get; }

        IUnitContainer UnitContainer { get; }

        IUnitEffector Effector { get; }

        ICollection<IUnit> Units { get; }

        void Run();

        void Stop();

        void AddUnit(IUnit unit);

        void RemoveUnit(IUnit unit);
    }
}
