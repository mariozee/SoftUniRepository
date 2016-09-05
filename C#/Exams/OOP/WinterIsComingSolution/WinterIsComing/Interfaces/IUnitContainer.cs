namespace WinterIsComing.Interfaces
{
    using System.Collections.Generic;

    public interface IUnitContainer
    {
        IEnumerable<IUnit> GetUnitsInRange(int row, int col, int range);

        void ChangePosition(IUnit unit, int newRow, int newCol);

        void Remove(IUnit unit);

        void Add(IUnit unit);
    }
}
