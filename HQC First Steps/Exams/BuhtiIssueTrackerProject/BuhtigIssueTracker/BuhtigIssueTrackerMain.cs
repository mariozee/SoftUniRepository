namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;

    class BuhtigIssueTrackerMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new Engine();
            engine.Run();
        }
    }
}