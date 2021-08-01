﻿using System;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Tire[] tires;
        private Engine engine;

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make {
            get { return make; }

            set { make = value; }
        }

        public string Model {
            get { return model; }

            set { model = value; }
        }

        public int Year {
            get { return year; }

            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }

            set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }

            set { fuelConsumption = value; }
        }

        public Engine Engine { 
            get { return engine; } 
            set { engine = value; } }

        public Tire[] Tires { 
            get { return tires; } 
            set { tires = value; } }

        public void Drive(double distance)
        {
            var remainingFuel = FuelQuantity - ((distance * FuelConsumption)/100);

            if (remainingFuel >= 0)
            {
                FuelQuantity = remainingFuel;
            }

            else
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.Append($"FuelQuantity: {this.FuelQuantity}");
            return sb.ToString();
        }
    }
}
