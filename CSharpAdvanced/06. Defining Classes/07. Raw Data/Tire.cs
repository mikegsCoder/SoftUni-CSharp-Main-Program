namespace P07.RawData
{
    public class Tire
    {
        public Tire(double tirePressure, int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
        }
        public double TirePressure { get; set; }
        public int TireAge { get; set; }
    }
}

