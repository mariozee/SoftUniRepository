using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComingMain.Interfaces
{
    public interface ICommandDispatcher
    {
        IEngine Engine { get; set; }

        void DispatchCommand(string[] commandArgs);

        void SeedCommands();
    }
}
