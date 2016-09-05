namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class CombatHandler : ICombatHandler
    {
        public IUnit Unit { get; set; }

        public abstract ISpell GenerateAttack();

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);
    }
}
