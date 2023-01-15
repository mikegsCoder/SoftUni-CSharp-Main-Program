using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Creator))]
        [StringLength(36)]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        [ForeignKey(nameof(Repository))]
        [StringLength(36)]
        public string RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
