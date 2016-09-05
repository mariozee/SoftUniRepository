namespace Blobs
{
    using Interfaces;
    using Models;
    using Engine;

    public class Startup
    {
        static void Main()
        {
            BlobsEngine.Instance.Run();
            
        }
    }
}
