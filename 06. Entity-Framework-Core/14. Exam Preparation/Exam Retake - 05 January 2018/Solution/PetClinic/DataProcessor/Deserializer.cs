namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dto.Import;
    using PetClinic.DataProcessor.ImportDto;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            List<AnimalAid> animalAids = JsonConvert.DeserializeObject<List<AnimalAid>>(jsonString);

            List<AnimalAid> validAnimalAids = new List<AnimalAid>();
            StringBuilder sb = new StringBuilder();

            HashSet<string> existingAnimalAids = new HashSet<string>();

            foreach (var animalAid in animalAids)
            {
                if (!IsValid(animalAid) || existingAnimalAids.Contains(animalAid.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validAnimalAids.Add(animalAid);
                existingAnimalAids.Add(animalAid.Name);
                sb.AppendLine(string.Format(SuccessMessage, animalAid.Name));
            }

            context.AddRange(validAnimalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            List<ImportAnimalDto> animals = JsonConvert.DeserializeObject<List<ImportAnimalDto>>(jsonString);

            List<Animal> validAnimals = new List<Animal>();
            StringBuilder sb = new StringBuilder();

            foreach (var animal in animals)
            {
                bool passportExists = context.Passports.Any(p => p.SerialNumber == animal.Passport.SerialNumber);

                if (!IsValid(animal) || !IsValid(animal.Passport) || passportExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime regDate = DateTime.ParseExact(animal.Passport.RegistrationDate, @"dd-MM-yyyy", CultureInfo.InvariantCulture);

                Animal a = new Animal()
                {
                    Name = animal.Name,
                    Type = animal.Type,
                    Age = animal.Age,
                    Passport = new Passport()
                    {
                        SerialNumber = animal.Passport.SerialNumber,
                        OwnerName = animal.Passport.OwnerName,
                        OwnerPhoneNumber = animal.Passport.OwnerPhoneNumber,
                        RegistrationDate = regDate
                    }
                };

                validAnimals.Add(a);
                sb.AppendLine(string.Format(SuccessMessage, $"{animal.Name} Passport №: {animal.Passport.SerialNumber}"));
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Vet[]), new XmlRootAttribute("Vets"));
            Vet[] vets = (Vet[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Vet> validVets = new List<Vet>();

            foreach (var vet in vets)
            {
                bool vetPhoneExists = validVets.Any(x => x.PhoneNumber == vet.PhoneNumber);

                if (!IsValid(vet) || vetPhoneExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Vet v = new Vet()
                {
                    Name = vet.Name,
                    Profession = vet.Profession,
                    Age = vet.Age,
                    PhoneNumber = vet.PhoneNumber
                };

                validVets.Add(v);
                sb.AppendLine(string.Format(SuccessMessage, v.Name));
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Procedure[]), new XmlRootAttribute("Procedures"));
            ImportProcedureDto[] procedures = (ImportProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Procedure> validProcedures = new List<Procedure>();

            foreach (var procedure in procedures)
            {
                var vet = context.Vets.FirstOrDefault(v => v.Name == procedure.VetName);
                var animal = context.Animals.FirstOrDefault(a => a.PassportSerialNumber == procedure.AnimalSerialNumber);
                bool isDateValid = DateTime.TryParseExact(procedure.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

                if (!IsValid(procedure) || vet == null || animal == null || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Procedure p = new Procedure()
                {
                    Vet = vet,
                    Animal = animal,
                    DateTime = dateTime
                };

                foreach (var animalAidDto in procedure.AnimalAids)
                {
                    var animalAid = context.AnimalAids.FirstOrDefault(aa => aa.Name == animalAidDto.Name);
                    var isAnimalAidExisting = p.ProcedureAnimalAids.Any(paa => paa.AnimalAid.Name == animalAidDto.Name);

                    if (!IsValid(animalAidDto) || animalAid == null || isAnimalAidExisting)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ProcedureAnimalAid paa = new ProcedureAnimalAid()
                    {
                        Procedure = p,
                        AnimalAid = animalAid
                    };

                    p.ProcedureAnimalAids.Add(paa);
                }

                validProcedures.Add(p);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(validProcedures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
         
        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
