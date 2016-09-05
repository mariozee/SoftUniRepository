using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Engine;
using System.Reflection;
using LambdaCore_Skeleton.Models.Fragments;

namespace LambdaCore_Skeleton.Commands
{
    public class AttachFragment : Command
    {
        public AttachFragment(CoreData coreData, string[] parametars)
            : base(coreData, parametars)
        {
        }

        public override string Execute()
        {
            string fragmentName = this.Params[0];
            string name = this.Params[1];
            int pressure = int.Parse(this.Params[2]);
            var fragmentType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == (fragmentName + "Fragment"));
            if (fragmentType == null)
            {
                throw new ArgumentNullException(String.Format(GlobalMessages.FailedAttachFragment, name));
            }

            var fragmnet = Activator.CreateInstance(fragmentType, name, pressure) as BaseFragment;
            if (this.CoreData.SelectedCore == null)
            {
                throw new ArgumentNullException(String.Format(GlobalMessages.FailedAttachFragment, name));
            }

            this.CoreData.SelectedCore.AttachFragment(fragmnet);

            string message = string.Format(GlobalMessages.SuccessAttacedFragment, name, this.CoreData.SelectedCore.Name);
            return message;
        }
    }
}
