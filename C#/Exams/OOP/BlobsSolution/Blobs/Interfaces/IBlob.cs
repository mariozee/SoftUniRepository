using Blobs.Models;

namespace Blobs.Interfaces
{
    public interface IBlob
    {
        string Name { get; }

        int Health { get; set; }

        int InitialHealth { get; }

        int Damage { get; set; }

        int InitialDamamge { get; }

        int Attack();

        bool IsAlive();

        void Update();

        IBehavior Behave { get; }

        event OnToggleBehaviorEventHandler OnToggleBehavior;

        event OnBlobDeathEventHandler OnBlobDeath;
    }
}