namespace BuhtigIssueTracker
{
    using Interfaces;

    public class Dispatcher
    {
        Dispatcher(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public Dispatcher() 
            : this(new IssueTracker())
        {
        }

        IIssueTracker Tracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.actionName)
            {
                case "RegisterUser":
                    return 
                        Tracker.RegisterUser(endpoint.parameter["username"], 
                        endpoint.parameter["password"], 
                        endpoint.parameter["confirmPassword"]);
                case "LoginUser":
                    return 
                        Tracker.LoginUser(endpoint.parameter["username"], 
                        endpoint.parameter["password"]);
                case "LogoutUser":
                    return 
                        Tracker.LogoutUser();
                case "CreateIssue":
                    return 
                        Tracker.CreateIssue(endpoint.parameter["title"], 
                        endpoint.parameter["description"],
                        (IssuePrority)System.Enum.Parse(typeof(IssuePrority), 
                        endpoint.parameter["priority"], true),
                        endpoint.parameter["tags"].Split('|'));
                case "RemoveIssue":
                    return 
                        Tracker.RemoveIssue(int.Parse(endpoint.parameter["id"]));
                case "AddComment":
                    return 
                        Tracker.AddComment(
                        int.Parse(endpoint.parameter["id"]),
                        endpoint.parameter["text"]);
                case "MyIssues":
                    return 
                        Tracker.GetMyIssues();
                case "MyComments":
                    return 
                        Tracker.GetMyComments();
                case "Search":
                    return 
                        Tracker.SearchForIssues(endpoint.parameter["tags"].Split('|'));
                default:
                    return 
                        string.Format("Invalid action: {0}", endpoint.actionName);
            }
        }
    }
}