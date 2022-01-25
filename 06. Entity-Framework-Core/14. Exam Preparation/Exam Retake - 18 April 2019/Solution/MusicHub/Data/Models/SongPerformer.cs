using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [ForeignKey("Song")]
        public int SongId { get; set; }

        public virtual Song Song { get; set; }

        [ForeignKey("Performer")]
        public int PerformerId { get; set; }

        public virtual Performer Performer { get; set; }
    }
}
