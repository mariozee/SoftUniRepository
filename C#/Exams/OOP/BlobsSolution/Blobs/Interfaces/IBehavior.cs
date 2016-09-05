namespace Blobs.Interfaces
{
    public interface IBehavior
    {
        void Behave(IBlob blob);

        void Update(IBlob blob);        
    }
}
