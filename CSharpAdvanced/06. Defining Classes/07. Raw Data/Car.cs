namespace P07.RawData
{
    public class Car
    {       
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, 
            double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);            
            this.Cargo = new Cargo(cargoWeight, cargoType);            
            this.Tires = new Tire[4];
            this.Tires[0] = new Tire(tire1Pressure, tire1Age);
            this.Tires[1] = new Tire(tire2Pressure, tire2Age);
            this.Tires[2] = new Tire(tire3Pressure, tire3Age);
            this.Tires[3] = new Tire(tire4Pressure, tire4Age);
        }
        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }
    }
}
