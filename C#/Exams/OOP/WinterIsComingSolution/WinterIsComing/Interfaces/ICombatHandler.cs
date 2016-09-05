namespace WinterIsComing.Interfaces
{
    using System.Collections.Generic;

    public interface ICombatHandler
    {
        IUnit Unit { get; set; }

        IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        ISpell GenerateAttack();
    }
}
