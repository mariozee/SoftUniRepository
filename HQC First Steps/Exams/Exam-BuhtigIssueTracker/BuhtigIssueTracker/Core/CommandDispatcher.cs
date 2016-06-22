namespace BuhtigIssueTracker.Core
{
    using BuhtigIssueTracker;
    using Enum;
    using Interfaces;
    using System;

    public class CommandDispatcher
    {
        CommandDispatcher(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public CommandDispatcher()
            : this(new CommandExecuter())
        {
        }

        IIssueTracker Tracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return Tracker.RegisterUser(endpoint.Parameters["username"],
                           endpoint.Parameters["password"],
                           endpoint.Parameters["confirmPassword"]);
                case "LoginUser":
                    return Tracker.LoginUser(endpoint.Parameters["username"],
                           endpoint.Parameters["password"]);
                case "LogoutUser":
                    return Tracker.LogoutUser();
                case "CreateIssue":
                    return Tracker.CreateIssue(endpoint.Parameters["title"],
                           endpoint.Parameters["description"],
                           (IssuePrioritetType)Enum.Parse(typeof(IssuePrioritetType),
                           endpoint.Parameters["priority"], true),
                           endpoint.Parameters["tags"].Split('|'));
                case "RemoveIssue":
                    return Tracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));
                case "AddComment":
                    //FIX: change searching parameter from "Id" to "id"
                    int issueId = int.Parse(endpoint.Parameters["id"]);
                    string commentText = endpoint.Parameters["text"];

                    return Tracker.AddComment(issueId, commentText);
                case "MyIssues":
                    return Tracker.GetMyIssues();
                case "MyComments":
                    return Tracker.GetMyComments();
                case "Search":
                    return Tracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.ActionName);
            }
        }
    }
}
