﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlType("Card")]
    public class CardImportDto
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        public string CardType { get; set; }
    }
}
