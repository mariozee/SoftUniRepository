using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePartsFactory.Interfaces;

namespace BikePartsFactory.Core
{
    public class FactoryData : IFactoryData
    {
        private IList<IPart> partsList = new List<IPart>();

        public IEnumerable<IPart> PartsList
        {
            get { return this.partsList; }
        }

        public void AddPartToList(IPart part)
        {
            if (part == null)
            {
                throw new ArgumentException();
            }

            partsList.Add(part);
        }
    }
}
