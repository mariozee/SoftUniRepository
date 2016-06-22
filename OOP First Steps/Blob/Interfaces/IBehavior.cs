using System;
using Blob.EventArgs;

namespace Blob.Interfaces
{
    public interface IBehavior : IUpdateable, IApplyEffect
    {
        event EventHandler<BlobEventArgs> OnBehaviorToggleEventHandler;
        bool CanTriggerBehavior
        {
            get;
        }
    }
}
