using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComingMain.Interfaces;

namespace WinterIsComingMain.Models.Spells
{
    public abstract class AbstractSpell : ISpell
    {
        private int damage;
        private int energyCost;

        public AbstractSpell(int damage, int energyCost)
        {
            this.Damge = damage;
            this.EnergyCost = energyCost;
        }

        public int Damge
        {
            get
            {
                return this.damage;
            }
            protected set
            {
                this.damage = value;
            }
        }

        public int EnergyCost
        {
            get
            {
                return this.energyCost;
            }
            protected set
            {
                this.energyCost = value;
            }
        }
    }
}
