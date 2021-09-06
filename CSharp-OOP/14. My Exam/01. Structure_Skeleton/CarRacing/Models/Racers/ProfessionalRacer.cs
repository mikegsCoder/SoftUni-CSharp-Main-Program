using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int DrivingEXperience = 30;
        private const string RacingBEhavior = "strict";

        public ProfessionalRacer(string username, ICar car) 
            : base(username, RacingBEhavior, DrivingEXperience, car)
        {
        }

        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 10;
        }
    }
}
