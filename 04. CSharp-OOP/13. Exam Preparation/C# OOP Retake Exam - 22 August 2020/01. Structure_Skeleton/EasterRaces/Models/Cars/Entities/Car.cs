﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;


        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }


        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.horsePower * laps;
        }                     
    }
}
