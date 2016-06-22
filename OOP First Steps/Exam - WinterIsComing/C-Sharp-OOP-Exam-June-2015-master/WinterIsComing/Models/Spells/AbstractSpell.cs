using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public abstract class AbstractSpell : ISpell
    {
        private int _damage;
        private int _energyCost;

        public AbstractSpell(int damage, int energyCost)
        {
            this._damage = damage;
            this._energyCost = energyCost;
        }

        public int Damage 
        {
            get
            {
                return this._damage;
            }
            protected set
            {
                this._damage = value;
            }
        }

        public int EnergyCost 
        {
            get
            {
                return this._energyCost;
            }
            protected set
            {
                this._energyCost = value;
            }
        }
    }
}
