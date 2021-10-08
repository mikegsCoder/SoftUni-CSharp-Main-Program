using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Ski ski)
        {
            if (this.data.Count == this.Capacity)
            {
                return;
            }

            this.data.Add(ski);
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = this.data.FirstOrDefault
                (s => s.Manufacturer == manufacturer && s.Model == model);

            if (skiToRemove == null)
            {
                return false;
            }

            this.data.Remove(skiToRemove);
            return true;
        }

        public Ski GetNewestSki()
        {
            Ski skiToReturn = this.data.FirstOrDefault
                (s => s.Year == this.data.Max(x => x.Year));

            return skiToReturn;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski skiToReturn = this.data.FirstOrDefault
                (s => s.Manufacturer == manufacturer && s.Model == model);

            return skiToReturn;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (Ski ski in this.data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
