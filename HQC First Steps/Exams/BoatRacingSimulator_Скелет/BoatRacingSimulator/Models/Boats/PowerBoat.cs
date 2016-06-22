namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;

    public class PowerBoat : Boat
    {
        public PowerBoat(string model, int weight, IBoatEngine firstEngine, IBoatEngine secondEngine)
            : base(model, weight)
        {
            this.FirstEngine = firstEngine;
            this.SecondEngine = secondEngine;
        }

        public IBoatEngine FirstEngine { get; private set; }

        public IBoatEngine SecondEngine { get; private set; }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.FirstEngine.Output + this.SecondEngine.Output - this.Weight + (race.OceanCurrentSpeed / 5d);
            return speed;
        }
    }
}
