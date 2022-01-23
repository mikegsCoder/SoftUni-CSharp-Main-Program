using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Dtos.Import
{
    public class PostIdImport
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
