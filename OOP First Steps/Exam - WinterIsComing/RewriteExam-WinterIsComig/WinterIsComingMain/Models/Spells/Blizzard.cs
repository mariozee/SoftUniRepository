using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Models.Spells
{
    public class Blizzard : AbstractSpell
    {
        private const int DefaultBlizzardEnergyCost = 40;

        public Blizzard(int damage)
            : base(damage, DefaultBlizzardEnergyCost)
        {
        }
    }
}
