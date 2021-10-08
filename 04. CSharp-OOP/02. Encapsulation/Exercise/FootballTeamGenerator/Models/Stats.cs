using System;
using System.Collections.Generic;
using System.Text;

using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;
        private const double STATS_CNT = 5;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                this.ValidateStat(nameof(Endurance), value);

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                this.ValidateStat(nameof(Sprint), value);

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                this.ValidateStat(nameof(Dribble), value);

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                this.ValidateStat(nameof(Passing), value);

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                this.ValidateStat(nameof(Shooting), value);

                this.shooting = value;
            }
        }
        public double AverageStat =>
            (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) 
            / STATS_CNT;

        private void ValidateStat(string name, int value)
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException(String.Format
                    (GlobalConstants.InvalidStatExcMsg,name, MIN_STAT, MAX_STAT));
            }
        }
    }
}
