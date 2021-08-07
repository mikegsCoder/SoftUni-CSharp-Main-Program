namespace Cars
{
    public interface ICar
    {
        string Model { get; }
        string Color { get; }
        public string Start();
        public string Stop();
    }
}
