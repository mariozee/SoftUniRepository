namespace FurnitureManufacturer.Interfaces
{
    using Models;

    public interface IFurniture
    {
        string Model { get; }

        MaterialType Material { get; }

        decimal Price { get; }

        decimal Height { get; }
    }
}