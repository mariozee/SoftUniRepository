namespace LearningSystem.Interfaces
{
    using System.Collections.Generic;

    public interface IRoute
    {
        string ControlerName { get; }

        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}
