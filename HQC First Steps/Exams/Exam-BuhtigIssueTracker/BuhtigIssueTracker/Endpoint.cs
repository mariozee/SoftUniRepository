namespace BuhtigIssueTracker
{
    using System.Collections.Generic;
    using System.Net;
    using System.Linq;
    using Interfaces;

    public class Endpoint : IEndpoint
    {
        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        public Endpoint(string inputUrl)
        {
            int questionMark = inputUrl.IndexOf('?');
            if (questionMark != -1)
            {
                this.ActionName = inputUrl.Substring(0, questionMark);
                var pairs = inputUrl.Substring(questionMark + 1).
                    Split('&').
                    Select(x => x.Split('=').
                    Select(xx => WebUtility.
                    UrlDecode(xx)).
                    ToArray());
                 
                var parameters = new Dictionary<string, string>();
                foreach (var pair in pairs)
                {
                    parameters.Add(pair[0], pair[1]);
                }

                this.Parameters = parameters;
            }
            else
            {
                this.ActionName = inputUrl;
            }
        }
    }
}