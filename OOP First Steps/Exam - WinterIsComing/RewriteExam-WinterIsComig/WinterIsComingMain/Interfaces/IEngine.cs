using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Interfaces
{
    public  interface IEngine
    {
        void Start();

        void Stop();

        void InsertUnit(IUnit unit);

        void RemoveUnit(IUnit unit);

        IEnumerable<IUnit> Units { get; }

        IUnitContainer UnitContainer { get; }

        IOutputWriter OutputWriter { get; }

        IUnitEffector UnitEffector { get; }
    }
}
