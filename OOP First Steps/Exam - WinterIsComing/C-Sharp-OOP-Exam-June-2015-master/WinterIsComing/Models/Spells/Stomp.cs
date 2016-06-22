using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class Stomp : AbstractSpell
    {
        public Stomp(int damage)
            : base(damage, 10)
        {

        }
    }
}
