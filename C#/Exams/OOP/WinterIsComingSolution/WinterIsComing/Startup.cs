namespace WinterIsComing
{
    using Core;

    public class Startup
    {
        static void Main(string[] args)
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var container = new MatrixContainer();
            var dispatcher = new CommandDispatcher();
            var effector = new UnitEffector();

            var engine = new Engine(reader, writer, container, dispatcher, effector);
            engine.Run();
        }
    }
}
