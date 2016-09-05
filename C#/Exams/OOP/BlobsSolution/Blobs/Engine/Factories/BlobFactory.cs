namespace Blobs.Engine.Factories
{
    using Interfaces;
    using Models;

    public class BlobFactory : IBlobFactory
    {
        public IBlob CreateBlob(string name, int health, int damage, IAttack attack, IBehavior behavior)
        {
            IBlob blob = new Blob(name, health, damage, attack, behavior);

            return blob;
        }
    }
}
