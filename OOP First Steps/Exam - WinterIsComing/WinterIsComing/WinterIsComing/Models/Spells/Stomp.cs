using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class Stomp : Spells
    {
        private const int DefaultEnergyCost = 10;

        public Stomp(int damege)
            : base(damege, DefaultEnergyCost)
        {
        }
    }
}
