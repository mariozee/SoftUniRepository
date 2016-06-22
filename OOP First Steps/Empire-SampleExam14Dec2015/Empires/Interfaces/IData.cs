namespace Empires.Interfaces
{
    using System.Collections.Generic;
    using Enums;

    public interface IData
    {
        IEnumerable<IBuilding> Buildings { get; }

        void AddBuilding(IBuilding building);

        IDictionary<string, int> Units { get; }

        void AddUint(IUnit unit);

        IDictionary<ResourceType, int> Resources { get; }
    }
}
