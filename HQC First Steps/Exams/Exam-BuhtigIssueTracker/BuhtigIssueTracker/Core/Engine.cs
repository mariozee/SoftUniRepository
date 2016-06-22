namespace BuhtigIssueTracker.Core
{
    using BuhtigIssueTracker;
    using Interfaces;
    using System;

    public class BuhtingIssueTrackerEngine : IEngine
    {
        private CommandDispatcher dispatcher;

        public BuhtingIssueTrackerEngine(CommandDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public BuhtingIssueTrackerEngine()
            : this(new CommandDispatcher())
        {
        }

        public void Run()
        {
            while (true)
            {
                string inputUrl = Console.ReadLine();

                //FIX: != to ==
                if (inputUrl == null)
                {
                    break;
                }

                inputUrl = inputUrl.Trim();

                //FIX: string.IsNullOrEmpty() to !string.IsNullOrEmpty()
                if (!string.IsNullOrEmpty(inputUrl))
                {
                    try
                    {
                        var endPoint = new Endpoint(inputUrl);
                        string viewResult = this.dispatcher.DispatchAction(endPoint);
                        Console.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
