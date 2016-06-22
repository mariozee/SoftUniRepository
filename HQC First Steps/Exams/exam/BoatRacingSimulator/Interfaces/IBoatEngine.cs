using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRacingSimulator.Interfaces
{
    public interface IBoatEngine : IModelable
    {
        int CachedOutput { get; }

        int Horsepower { get; }

        int Displacement { get; }

        int Output { get; }
    }
}
