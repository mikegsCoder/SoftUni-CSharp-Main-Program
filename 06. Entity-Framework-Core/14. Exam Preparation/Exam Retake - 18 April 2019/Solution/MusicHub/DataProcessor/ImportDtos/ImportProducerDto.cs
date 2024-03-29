﻿using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducerDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359 \d{3} \d{3} \d{3}$")]
        public string PhoneNumber { get; set; }

        public ImportAlbumDto[] Albums { get; set; }
    }
}
