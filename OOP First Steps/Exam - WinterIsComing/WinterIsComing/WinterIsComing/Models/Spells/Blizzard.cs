using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Models.Spells
{
    public class Blizzard : Spells
    {
        private const int DefaultEnergyCost = 40;

        public Blizzard(int damege)
            : base(damege, DefaultEnergyCost)
        {
        }
    }
}
