namespace P08.CarSalesman
{
    public class Engine
    {
        public Engine()
        {

        }
        public Engine(string model, string power) : this()
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, string power, string displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, string power, string displacement, string efficiency) : this(model, power,displacement)
        {
            this.Efficiency = efficiency;
        }
        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
