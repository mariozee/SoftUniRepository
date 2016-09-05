using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Interfaces;

namespace WinterIsComing.Core.Commands
{
    public class StatusCommand : Command
    {
        public StatusCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string unitName = commandArgs[1];

            var unit = this.Engine.Units.Where(u => u.Name == unitName).FirstOrDefault();

            if (unit == null)
            {
                throw new GameException(GlobalMessages.CantBeNull);
            }

            this.Engine.Writer.WriteLine(unit.ToString());
        }
    }
}
