namespace FurnitureManufacturer.Interfaces
{
    public interface ITable : IFurniture
    {
        decimal Lenght { get; }

        decimal Width { get; }

        decimal Area { get; }
    }
}
