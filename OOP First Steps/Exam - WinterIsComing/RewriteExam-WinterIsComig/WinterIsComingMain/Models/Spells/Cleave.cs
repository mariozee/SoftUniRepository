using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Models.Spells
{
    class Cleave : AbstractSpell
    {
        private const int DefaultCleaveEnregyCost = 15;

        public Cleave(int damage)
            : base(damage, DefaultCleaveEnregyCost)
        {
        }
    }
}
