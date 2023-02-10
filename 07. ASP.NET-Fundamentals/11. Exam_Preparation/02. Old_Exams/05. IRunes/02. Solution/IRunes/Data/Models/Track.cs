using System;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Data.Models
{
    public class Track
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
