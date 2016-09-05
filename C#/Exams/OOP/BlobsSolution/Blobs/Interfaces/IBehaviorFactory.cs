namespace Blobs.Interfaces
{
    public interface IBehaviorFactory
    {
        IBehavior CreateBehavior(string behaviorType);
    }
}
