using LambdaCore_Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Engine
{
    public class CoreData
    {
        public CoreData()
        {
            this.Data = new Dictionary<string, IBaseCore>();
        }

        public IDictionary<string, IBaseCore> Data { get; private set; }

        public IBaseCore SelectedCore { get; private set; }

        public void Add(string name, IBaseCore core)
        {
            if (this.Data.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            this.Data.Add(name, core);
        }

        public void Remove(string name)
        {
            if (!this.Data.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(GlobalMessages.FailedRemoveCore, name));
            }

            this.Data.Remove(name);
        }

        public void SetCore(string name)
        {
            if (!this.Data.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(GlobalMessages.FailedSelectCore, name));
            }

            this.SelectedCore = this.Data[name];
        }
    }
}
