using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spells
    {
        private const int DefaultEnergyCost = 15;

        public Cleave(int damege)
            : base(damege, DefaultEnergyCost)
        {
        }
    }
}
