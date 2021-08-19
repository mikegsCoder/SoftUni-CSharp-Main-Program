namespace P07.RawData
{
    public class Cargo
    {
        public Cargo(int cargoWeight, string CargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = CargoType;
        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
