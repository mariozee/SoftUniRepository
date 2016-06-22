namespace AirConditionerTesting
{
    using AirConditionerTesting.Core;
    using AirConditionerTesting.UI;

    public class AirConditionerTestingMain
    {
        public static void Main()
        {
            var engine = new Engine(new ConsoleUserInterface());
            engine.Run();
        }
    }
}
