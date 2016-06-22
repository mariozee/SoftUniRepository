namespace BuhtigIssueTracker
{
    using Core;
    using System.Globalization;
    using System.Threading;

    public class BuhtigIssueTrackerMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new BuhtingIssueTrackerEngine();
            engine.Run();
        }
    }
}