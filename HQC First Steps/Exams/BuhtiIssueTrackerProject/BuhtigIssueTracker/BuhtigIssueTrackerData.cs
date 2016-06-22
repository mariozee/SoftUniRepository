namespace BuhtigIssueTracker
{
    using Models;
    using Interfaces;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        public int nextIssueId;

        public BuhtigIssueTrackerData()
        {
            nextIssueId = 1;
            UserData = new Dictionary<string, User>();
            IdIssueDic = new OrderedDictionary<int, Issue>();
            UserIssueDic = new MultiDictionary<string, Issue>(true);
            UserCommentDic = new MultiDictionary<User, Comment>(true);
            CommntsUser = new Dictionary<Comment, User>();
            TagIssueDic = new MultiDictionary<string, Issue>(true);
        }

        public User CurrentlyLogedUser { get; set; }

        public IDictionary<string, User> UserData { get; set; }

        public OrderedDictionary<int, Issue> IdIssueDic { get; set; }

        public MultiDictionary<string, Issue> UserIssueDic { get; set; }

        public MultiDictionary<string, Issue> TagIssueDic { get; set; }

        public MultiDictionary<User, Comment> UserCommentDic { get; set; }

        public Dictionary<Comment, User> CommntsUser { get; set; }

        public int AddIssue(Issue p) { return 0; }

        public void RemoveIssue(Issue p) { return; }
    }
}
