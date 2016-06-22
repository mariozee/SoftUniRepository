using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Models.Spells
{
    public class FireBreath : AbstractSpell
    {
        private const int DefaultFireBreathEnergyCost = 30;                         

        public FireBreath(int damage) 
            : base(damage, DefaultFireBreathEnergyCost)
        {
        }
    }
}
