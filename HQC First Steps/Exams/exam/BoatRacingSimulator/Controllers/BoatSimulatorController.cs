namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Database;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utility;
    using Models.Engines;
    using Models.Boats;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(BoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController()
            : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public BoatSimulatorDatabase Database { get; private set; }

        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IBoatEngine boatEngine;
            switch (engineType)
            {
                case EngineType.Jet:
                    boatEngine = new JetEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    boatEngine = new SterndriveEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.Database.Engines.Add(boatEngine);
            return string.Format(
                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.",
                model,
                horsepower,
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            var boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);

            return string.Format("Row boat with model {0} registered successfully.", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            var boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);

            return string.Format("Sail boat with model {0} registered successfully.", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            IBoatEngine firstEngine = this.Database.Engines.GetItem(firstEngineModel);
            IBoatEngine secondEngine = this.Database.Engines.GetItem(secondEngineModel);
            var boat = new PowerBoat(model, weight, firstEngine, secondEngine);
            this.Database.Boats.Add(boat);

            return string.Format("Power boat with model {0} registered successfully.", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            var engine = this.Database.Engines.GetItem(engineModel);
            var boat = new Yacht(model, weight, engine, cargoWeight);
            this.Database.Boats.Add(boat);

            return string.Format("Yacht with model {0} registered successfully.", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;

            return string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    distance, windSpeed, oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            IBoat boat = this.Database.Boats.GetItem(model);
            this.ValidateRaceIsSet();
            if (!this.CurrentRace.AllowsMotorboats && (boat is PowerBoat || boat is Yacht))
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.CurrentRace.AddParticipant(boat);

            return string.Format("Boat with model {0} has signed up for the current Race.", model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();
            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var orderedParticipants = this.FindFastest(participants);
            var first = orderedParticipants[0];
            var second = orderedParticipants[1];
            var third = orderedParticipants[2];

            var result = new StringBuilder();
            result.AppendLine(string.Format(
                "First place: {0} Model: {1} Time: {2}",
                first.Key.GetType().Name,
                first.Key.Model,
                first.Value == double.MaxValue ? "Did not finish!" : first.Value.ToString("0.00") + " sec"));
            result.AppendLine(string.Format(
                "Second place: {0} Model: {1} Time: {2}",
                second.Key.GetType().Name,
                second.Key.Model,
                second.Value == double.MaxValue ? "Did not finish!" : second.Value.ToString("0.00") + " sec"));
            result.Append(string.Format(
                "Third place: {0} Model: {1} Time: {2}",
                third.Key.GetType().Name,
                third.Key.Model,
                third.Value == double.MaxValue ? "Did not finish!" : third.Value.ToString("0.00") + " sec"));      

            this.CurrentRace = null;

            return result.ToString();
        }

        public string GetStatistic()
        {
            var allBoats = this.CurrentRace.GetParticipants();
            double powerBoatsCount = allBoats.Where(x => x.GetType().Name == "PowerBoat").Count();
            double rowBoatCount = allBoats.Where(x => x.GetType().Name == "RowBoat").Count();
            double sailBoatCount = allBoats.Where(x => x.GetType().Name == "SailBoat").Count();
            double yachtCount = allBoats.Where(x => x.GetType().Name == "Yacht").Count();

            double totalBoatsCount = powerBoatsCount + rowBoatCount + sailBoatCount + yachtCount;

            double powerBoatsPercentage = (powerBoatsCount / totalBoatsCount) * 100;
            double rowBoatPercentage = (rowBoatCount / totalBoatsCount) * 100;
            double sailBoatPercentage = (sailBoatCount / totalBoatsCount) * 100;
            double yachtPercentage = (yachtCount / totalBoatsCount) * 100;

            string statistics = string.Format("PowerBoat -> {0:F2}%{4}RowBoat -> {1:F2}%{4}SailBoat -> {2:F2}%{4}Yacht -> {3:F2}%",
                powerBoatsPercentage, rowBoatPercentage, sailBoatPercentage, yachtPercentage, Environment.NewLine);

            return statistics;
        }

        private List<KeyValuePair<IBoat, double>> FindFastest(IList<IBoat> participants)
        {
            Dictionary<IBoat, double> boatsTimeData = new Dictionary<IBoat, double>();
            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(this.CurrentRace);
                var time = this.CurrentRace.Distance / speed;
                if (time <= 0)
                {
                    time = double.MaxValue;
                }

                boatsTimeData.Add(participant, time);
            }

            var orderedBoatsTime = boatsTimeData.OrderBy(x => x.Value).ToList();

            return orderedBoatsTime;
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}
