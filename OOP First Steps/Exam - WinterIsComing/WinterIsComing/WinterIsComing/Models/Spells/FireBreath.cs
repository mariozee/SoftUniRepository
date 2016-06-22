using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spells
    {
        private const int DefaultEnergyCost = 30;

        public FireBreath(int damege)
            : base(damege, DefaultEnergyCost)
        {
        }
    }
}
