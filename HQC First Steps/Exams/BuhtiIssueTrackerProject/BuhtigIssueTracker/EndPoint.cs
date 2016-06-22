namespace BuhtigIssueTracker
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string command)
        {
            int questionMark = command.IndexOf('?');
            if (questionMark != -1)
            {
                this.actionName = command.Substring(0, questionMark);
                var pairs = command.Substring(questionMark + 1)
                    .Split('&')
                    .Select(x => x.Split('=')
                    .Select(xx => WebUtility.UrlDecode(xx))
                    .ToArray());

                var parameters = new Dictionary<string, string>();

                foreach (var pair in pairs)
                {
                    parameters.Add(pair[0], pair[1]);
                }

                this.parameter = parameters;
            }
            else
            {
                this.actionName = command;
            }
        }

        public string actionName { get; set; }
        public IDictionary<string, string> parameter { get; set; }
    }
}
