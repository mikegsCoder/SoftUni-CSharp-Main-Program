using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    public class CustomerCardTicketDto
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
