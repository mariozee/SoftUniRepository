namespace BoatRacingSimulator.Interfaces
{
    using Database;
    using Enumerations;

    public interface IBoatSimulatorController
    {
        IRace CurrentRace { get; }

        BoatSimulatorDatabase Database { get; }

        /// <summary>
        /// Method thats create engine for boats
        /// </summary>
        /// <param name="model">Model name of the engine</param>
        /// <param name="horsepower">Horsepower of the engine</param>
        /// <param name="displacement">Displacement of the engine</param>
        /// <param name="engineType">Type of the engine</param>
        /// <returns>in case of success returns created successfully message</returns>
        string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType);

        string CreateRowBoat(string model, int weight, int oars);

        string CreateSailBoat(string model, int weight, int sailEfficiency);

        string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel);

        string CreateYacht(string model, int weight, string engineModel, int cargoWeight);

        string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats);

        /// <summary>
        /// Sigh up boat to current race
        /// </summary>
        /// <param name="model">Model of the boat that will be added</param>
        /// <returns>in case of success returns successfull sign up message</returns>
        string SignUpBoat(string model);

        string StartRace();

        string GetStatistic();
    }
}
