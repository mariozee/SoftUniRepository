namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;
    using Utility;

    public class Yacht : Boat
    {
        private int cargoWeight;

        public Yacht(string model, int weight, IBoatEngine engine, int cargoWeight)
            : base(model, weight)
        {
            this.Engine = engine;
        }

        public IBoatEngine Engine { get; private set; }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.Engine.Output - (this.Weight + this.CargoWeight) + (race.OceanCurrentSpeed / 2d);

            return speed;
        }
    }
}
