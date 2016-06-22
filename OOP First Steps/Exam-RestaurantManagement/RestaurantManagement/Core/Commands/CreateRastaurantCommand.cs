namespace RestaurantManagement.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;

    public class CreateRastaurantCommand : AbstractCommand
    {
        public CreateRastaurantCommand(IEnigne engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            throw new NotImplementedException();
        }
    }
}
