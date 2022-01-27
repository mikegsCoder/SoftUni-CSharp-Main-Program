using System.Collections.Generic;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dtos.Export
{
    [XmlType("Procedure")]
    public class ProcedureDto
    {
        public string Passport { get; set; }

        public string OwnerNumber { get; set; }

        public string DateTime { get; set; }

        [XmlArray]
        public List<AnimalAidDto> AnimalAids { get; set; }
       
        public decimal TotalPrice { get; set; }
    }
}
