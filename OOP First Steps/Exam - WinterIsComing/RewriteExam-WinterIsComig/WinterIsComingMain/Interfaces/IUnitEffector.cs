using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Interfaces
{
    public interface IUnitEffector
    {
        void ApplyEffect(IEnumerable<IUnit> units);
    }
}
