using LambdaCore_Skeleton.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Commands
{
    public class DetachFragment : Command
    {
        public DetachFragment(CoreData coreData, string[] parametars)
            : base(coreData, parametars)
        {
        }

        public override string Execute()
        {
            if (this.CoreData.SelectedCore == null)
            {
                throw new ArgumentNullException(GlobalMessages.FailedDettachFragment);
            }

            var fragment = this.CoreData.SelectedCore.DetachFragmnet();
            string message = string.Format(GlobalMessages.SuccessDettachedFragment, fragment.Name, this.CoreData.SelectedCore.Name);

            return message;
        }
    }
}
