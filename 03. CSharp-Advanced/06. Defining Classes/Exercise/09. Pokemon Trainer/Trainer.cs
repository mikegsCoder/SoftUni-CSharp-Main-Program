namespace P09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int numberOfBages)
        {
            this.Name = name;
            this.NumberOfBages = numberOfBages;            
        }
        public string Name { get; set; }
        public int NumberOfBages { get; set; }
    }
}
