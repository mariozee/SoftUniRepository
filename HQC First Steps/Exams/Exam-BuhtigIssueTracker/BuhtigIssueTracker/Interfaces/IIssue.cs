namespace BuhtigIssueTracker.Interfaces
{
    using Enum;
    using Models;
    using System.Collections.Generic;

    public interface IIssue
    {
        int Id { get; set; }

        IssuePrioritetType Priority { get; }

        IList<string> Tags { get; }

        IList<IComment> Comments { get; }

        string Title { get; }

        string Description { get; }

        void AddComment(IComment comment);
    }
}
