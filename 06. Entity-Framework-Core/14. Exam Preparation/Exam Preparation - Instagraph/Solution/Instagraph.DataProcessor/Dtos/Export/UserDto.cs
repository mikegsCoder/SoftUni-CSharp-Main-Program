using System.Xml.Serialization;

namespace Instagraph.DataProcessor.Dtos.Export
{
    [XmlType("user")]
    public class UserDto
    {
        public string Username { get; set; }

        public int MostComments { get; set; }
    }
}
