using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePartsFactory.Interfaces
{
    public interface IFrameMenuCommandExecute
    {
        IList<string> FrameSpecification { get; }

        void ExecuteSelectFrameTypeMenu(
            IConsoleReader reader,
            IConsoleWriter writer, 
            IConsoleClear clear, 
            IMenu menu,
            IEngine engine);
    }
}
