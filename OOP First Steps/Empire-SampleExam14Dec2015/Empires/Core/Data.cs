using Empires.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Enums;

namespace Empires.Core
{
    public class Data : IData
    {
        private ICollection<IBuilding> buildings = new List<IBuilding>();


        public Data()
        {
            this.Resources = new Dictionary<ResourceType, int>();
            this.Units = new Dictionary<string, int>();
        }

        private void InitResources()
        {
            var resourseTypes = Enum.GetValues(typeof(ResourceType));
            foreach (ResourceType resourceType in resourseTypes)
            {
                this.Resources.Add(resourceType, 0);
            }
        }

        public IEnumerable<IBuilding> Buildings
        {
            get { return this.buildings; }
        }

        public IDictionary<ResourceType, int> Resources { get; }

        public IDictionary<string, int> Units { get; }


        public void AddBuilding(IBuilding building)
        {
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            this.buildings.Add(building);
        }

        public void AddUint(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            var unitType = unit.GetType().Name;

            if (!this.Units.ContainsKey(unitType))
            {
                this.Units.Add(unitType, 0);
            }

            this.Units[unitType]++;
        }
    }
}
