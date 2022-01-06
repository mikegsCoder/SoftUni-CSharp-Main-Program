using System;
using System.ComponentModel;

namespace CarDealer.Dtos.Import
{
    using CarDealer.Models;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class CarInputModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArrayItem("partId", IsNullable = false)]
        public CarsCarPartId[] parts { get; set; }

        [Serializable()]
        [DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public class CarsCarPartId
        {
            [XmlAttribute()]
            public byte id { get; set; }
        }
    }
}