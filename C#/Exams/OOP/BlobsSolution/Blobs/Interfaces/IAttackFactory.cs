namespace Blobs.Interfaces
{
    public interface IAttackFactory
    {
        IAttack CreateAttack(string attackType);
    }
}
