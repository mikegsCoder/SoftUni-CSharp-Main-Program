using System;
using System.Collections.Generic;
using System.Text;
using P01Vehicles.Interfaces;
using P01Vehicles.Common;

namespace P01Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";
        private const double FUEL_CONSUMPTION_INCREMENT_FULL = 1.4;

        private double fuelQuantity;
        private double tankCapacity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double TankCapacity 
        { 
            get => this.tankCapacity;
            private set 
            {
                this.tankCapacity = value;
            } 
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
           
            protected set
            {
                if (value > this.tankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }

        }
        public virtual double FuelConsumption { get; }


        public string Drive(double amount)
        {
            double fuelNeeded = amount * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, amount);
        }

        public string DriveEmpty(double amount)
        {
            double fuelNeeded = amount * (this.FuelConsumption - FUEL_CONSUMPTION_INCREMENT_FULL);

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, amount);
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuel);
            }
            else if (amount > (this.TankCapacity - this.FuelQuantity))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFuelQuantity, amount));
            }

            this.FuelQuantity += amount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
