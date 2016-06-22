using System;
using Blob.EventArgs;

namespace Blob.Interfaces
{
    public interface IBlob : IUpdateable
    {
        event EventHandler<BlobEventArgs> OnBlobDeath; 
        string Name
        {
            get; 
        }
        int Health { get; set; }
        int Damage { get; set; }
        IBehavior Behavior { get; }
        IAttack ProduceAttack();
        void AcceptAttack(IAttack attack);
    }
}
