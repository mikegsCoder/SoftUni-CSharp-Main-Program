using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Dtos.Import
{
    [XmlType("post")]
    public class PostImportDto
    {
        [XmlElement("caption")]
        [Required]
        public string Caption { get; set; }

        [Required]
        [XmlElement("user")]
        public string User { get; set; }

        [Required]
        [XmlElement("picture")]
        public string Path { get; set; }
    }
}
