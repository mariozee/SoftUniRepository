namespace Blobs.Interfaces
{
    using System.Collections.Generic;

    public interface IRenderer
    {
        IEnumerable<string> Input();

        void Ouptut(IEnumerable<string> output);
    }
}
