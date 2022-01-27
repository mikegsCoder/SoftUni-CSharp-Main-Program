using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class ProcedureAnimalAid
    {
        [Required]
        [ForeignKey("Procedure")]
        public int ProcedureId { get; set; }

        [Required]
        public virtual Procedure Procedure { get; set; }

        [Required]
        [ForeignKey("AnimalAid")]
        public int AnimalAidId { get; set; }

        [Required]
        public virtual AnimalAid AnimalAid { get; set; }
    }
}
