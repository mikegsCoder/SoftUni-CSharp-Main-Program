using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [XmlAttribute("price")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [XmlAttribute("seat")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]+$")]
        [MaxLength(8)]
        public string SeatingPlace { get; set; }

        public TicketTripImportDto Trip { get; set; }

        public CustomerCardTicketDto Card { get; set; }
    }
}
