namespace P08.CarSalesman
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string model, string engine) : this()
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, string engine, string weight) : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, string engine, string weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
    }
}
