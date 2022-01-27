namespace PetClinic.DataProcessor
{
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos.Export;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var result = context.Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .ToArray()
                .Select(a => new
                {
                    OwnerName = a.Passport.OwnerName,
                    AnimalName = a.Name,
                    Age = a.Age,
                    SerialNumber = a.Passport.SerialNumber,
                    RegisteredOn = a.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Age)
                .ThenBy(x => x.SerialNumber)
                .ToArray();

            var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var result = context.Procedures
                .ToArray()
                .Select(p => new ProcedureDto
                {
                    Passport = p.Animal.PassportSerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = p.ProcedureAnimalAids.Select(paa => new AnimalAidDto
                    {
                        Name = paa.AnimalAid.Name,
                        Price = paa.AnimalAid.Price
                    })
                    .ToList(),
                    TotalPrice = p.ProcedureAnimalAids.Sum(x => x.AnimalAid.Price)
                })
                .OrderBy(x => x.DateTime)
                .ThenBy(x => x.Passport)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            StringBuilder sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
