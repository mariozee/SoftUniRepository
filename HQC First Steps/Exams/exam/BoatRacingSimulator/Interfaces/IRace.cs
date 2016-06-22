namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;
    using BoatRacingSimulator.Models;

    public interface IRace
    {
        /// <summary>
        /// Represents distance of current race
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// Represents speed of the wind dor current race
        /// </summary>
        int WindSpeed { get; }

        /// <summary>
        /// Represents ocean speed for the current race
        /// </summary>
        int OceanCurrentSpeed { get; }

        /// <summary>
        /// Boolean value representing if motorboards are allowed to the race
        /// </summary>
        bool AllowsMotorboats { get; }

        /// <summary>
        /// The method add boats to the current race data
        /// </summary>
        /// <param name="boat">Element the well be added as participant it the race</param>
        void AddParticipant(IBoat boat);

        /// <summary>
        /// Method for get all participants in current event
        /// </summary>
        /// <returns>all participants in current event</returns>
        IList<IBoat> GetParticipants();
    }
}
