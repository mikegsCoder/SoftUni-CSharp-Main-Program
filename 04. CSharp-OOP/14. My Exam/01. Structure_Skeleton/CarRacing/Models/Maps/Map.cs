using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double racingBehaviorMultiplierOne = 0;
            double racingBehaviorMultiplierTwo = 0;

            if (racerOne.GetType().Name == "ProfessionalRacer")
            {
                racingBehaviorMultiplierOne = 1.2;
            }
            else
            {
                racingBehaviorMultiplierOne = 1.1;
            }

            if (racerTwo.GetType().Name == "ProfessionalRacer")
            {
                racingBehaviorMultiplierTwo = 1.2;
            }
            else
            {
                racingBehaviorMultiplierTwo = 1.1;
            }

            racerOne.Race();
            racerTwo.Race();

            double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierOne;
            double chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierTwo;

            string winnersName = string.Empty;

            if (chanceOfWinningOne > chanceOfWinningTwo)
            {
                winnersName = racerOne.Username;
            }
            else
            {
                winnersName = racerTwo.Username;
            }

            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnersName);
        }
    }
}
