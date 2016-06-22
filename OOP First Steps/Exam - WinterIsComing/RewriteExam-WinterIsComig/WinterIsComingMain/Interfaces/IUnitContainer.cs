using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Interfaces
{
    public interface IUnitContainer
    {
        IEnumerable<IUnit> GetUnitsInRange(int x, int y, int range);

        void Add(IUnit unit);

        void Remove(IUnit unit);

        void Move(IUnit unit, int newX, int newY);
    }
}
