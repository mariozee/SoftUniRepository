using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class FireBreath : AbstractSpell
    {
        public FireBreath(int damage)
            : base(damage, 30)
        {

        }
    }
}
