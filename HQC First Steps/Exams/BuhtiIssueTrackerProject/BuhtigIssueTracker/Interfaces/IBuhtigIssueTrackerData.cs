namespace BuhtigIssueTracker.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentlyLogedUser { get; set; }

        IDictionary<string, User> UserData { get; }

        OrderedDictionary<int, Issue> IdIssueDic { get; }

        MultiDictionary<string, Issue> UserIssueDic { get; }

        MultiDictionary<string, Issue> TagIssueDic { get; }

        MultiDictionary<User, Comment> UserCommentDic { get; }

        int AddIssue(Issue p);

        void RemoveIssue(Issue p);
    }
}
