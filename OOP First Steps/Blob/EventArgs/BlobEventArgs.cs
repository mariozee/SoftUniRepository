using Blob.Interfaces;

namespace Blob.EventArgs
{
    public class BlobEventArgs : System.EventArgs
    {
        public IBlob Blob
        {
            get; private set;
        }

        public BlobEventArgs(IBlob blob)
        {
            this.Blob = blob;
        }
    }
}
