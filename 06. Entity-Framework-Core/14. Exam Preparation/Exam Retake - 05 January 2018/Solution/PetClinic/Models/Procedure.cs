using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetClinic.Models
{
    public class Procedure
    {
        public Procedure()
        {
            this.ProcedureAnimalAids = new HashSet<ProcedureAnimalAid>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        [Required]
        public virtual Animal Animal { get; set; }

        [Required]
        [ForeignKey("Vet")]
        public int VetId { get; set; }

        [Required]
        public virtual Vet Vet { get; set; }

        public virtual ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }

        public decimal Cost => this.ProcedureAnimalAids.Sum(x => x.AnimalAid.Price);

        [Required]
        public DateTime DateTime { get; set; }
    }
}
