namespace AirConditionerTesting.Core
{
    using System;
    using Interfaces;
    using CommandManagement;

    public class Engine
    {
        public CommandDispatcher commandDispatcher;

        public IUserInterface userInterface;

        public Endpoint command;

        public object GoodStuff { get; private set; }

        public Engine(IUserInterface userInterface)
        {
            this.commandDispatcher = new CommandDispatcher(this);
            this.userInterface = userInterface;
        }


        public void Run()
        {
            while (true)
            {
                string input = this.userInterface.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                input = input.Trim();
                try
                {
                    command = new Endpoint(input);
                    string output = this.commandDispatcher.DispatchCommand();
                    userInterface.WriteLine(output);
                }
                catch (Exception ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
            }
        }

        public string Status()
        {
            int reports = AirConditionsData.GetReportsCount();
            double airConditioners = AirConditionsData.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(GlobalMessages.STATUS, percent);
        }

        public void ValidateParametersCount(Endpoint command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(GlobalMessages.INVALIDCOMMAND);
            }
        }
    }
}
