using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Models.Spells
{
    public class Stomp : AbstractSpell
    {
        private const int DefaultStompEnergyCost = 10;

        public Stomp(int damage)
            : base(damage, DefaultStompEnergyCost)
        {
        }
    }
}
