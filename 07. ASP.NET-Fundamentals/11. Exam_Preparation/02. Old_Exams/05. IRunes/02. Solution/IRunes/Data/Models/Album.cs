﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Data.Models
{
    public class Album
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Cover { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
