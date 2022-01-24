using Stations.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class CustomerCard
    {
        public CustomerCard()
        {
            BoughtTickets = new List<Ticket>();
        }

        public CustomerCard(string name, int age, CardType type) : this()
        {
            Name = name;
            Age = age;
            Type = type;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        public CardType Type { get; set; } = CardType.Normal;

        public ICollection<Ticket> BoughtTickets { get; set; }
    }
}
