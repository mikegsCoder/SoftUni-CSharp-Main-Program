using System;

namespace _06._Speed_Racing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance = 0;

        public Car()
        {
        }
        public Car(string model) :this()
        {
            this.model = Model;
        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) :this(model)
        {
            this.fuelAmount = FuelAmount;
            this.fuelConsumptionPerKilometer = FuelConsumptionPerKilometer;
        }
        public string Model 
        { get => this.model; set => this.model = value; }
        public double FuelAmount 
        { get => this.fuelAmount; set => this.fuelAmount = value; }
        public double FuelConsumptionPerKilometer 
        { get => this.fuelConsumptionPerKilometer; set => this.fuelConsumptionPerKilometer = value; }
        public double TravelledDistance 
        { get => this.travelledDistance; set => this.travelledDistance = value; }

        public void Drive(int distance)
        {
            if (distance*this.FuelConsumptionPerKilometer <= this.FuelAmount)
            {
                this.FuelAmount -= distance * this.FuelConsumptionPerKilometer;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
