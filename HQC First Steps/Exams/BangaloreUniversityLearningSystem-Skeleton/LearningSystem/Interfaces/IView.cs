namespace LearningSystem.Interfaces
{
    public interface View
    {
        object Model { get; }

        string Display();
    }
}
