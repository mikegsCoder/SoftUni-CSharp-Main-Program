using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class Animal
    {
        public Animal()
        {
            this.Procedures = new HashSet<Procedure>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        public int Age { get; set; }

        [Required]
        public string PassportSerialNumber { get; set; }

        public virtual Passport Passport { get; set; }

        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
