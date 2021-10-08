using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int DrivingEXperience = 10;
        private const string RacingBEhavior = "aggressive";

        public StreetRacer(string username, ICar car)
            : base(username, RacingBEhavior, DrivingEXperience, car)
        {
        }

        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 5;
        }
    }
}
