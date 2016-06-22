using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public abstract class Spells : ISpell
    {
        public Spells(int damege, int energyCost)
        {
            this.Damage = damege;
            this.EnergyCost = energyCost;
        }

        public int Damage { get; set; }

        public int EnergyCost { get; set; }
    }
}
