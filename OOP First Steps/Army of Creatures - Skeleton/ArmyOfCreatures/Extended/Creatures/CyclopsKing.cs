using ArmyOfCreatures.Logic.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Specialties;
using ArmyOfCreatures.Extended.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    class CyclopsKing : Creature
    {
        private const int CyclopsKingAttack = 17;
        private const int CyclopsKingDefense = 13;
        private const int CyclopsKingHealth = 70;
        private const decimal CyclopsKingDamage = 18;

        private const int CyclopsAddAttackWhenSkipAttackPoints = 3;
        private const int CyclopsDoubleAttackWhenAttackingRoundsDuration = 4;
        private const int CyclopsDoubleDamageRoundsDuration = 1;

        protected CyclopsKing()
            : base(CyclopsKingAttack, CyclopsKingDefense, 
                   CyclopsKingHealth, CyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsAddAttackWhenSkipAttackPoints));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsDoubleAttackWhenAttackingRoundsDuration));
            this.AddSpecialty(new DoubleDamage(CyclopsDoubleDamageRoundsDuration));
        }
    }
}
