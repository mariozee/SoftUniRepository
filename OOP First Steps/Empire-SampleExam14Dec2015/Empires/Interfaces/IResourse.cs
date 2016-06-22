namespace Empires.Interfaces
{
    using Enums;

    public interface IResourse
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}
