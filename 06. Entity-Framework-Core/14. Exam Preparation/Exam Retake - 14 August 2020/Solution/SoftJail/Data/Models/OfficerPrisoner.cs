using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }

        public virtual Prisoner Prisoner { get; set; }

        [ForeignKey("Officer")]
        public int OfficerId { get; set; }

        public virtual Officer Officer { get; set; }
    }
}
