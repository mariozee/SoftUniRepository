namespace Blobs.Interfaces
{
    public interface IBlobFactory
    {
        IBlob CreateBlob(string name, int health, int damage, IAttack attack, IBehavior behavior);
    }
}
