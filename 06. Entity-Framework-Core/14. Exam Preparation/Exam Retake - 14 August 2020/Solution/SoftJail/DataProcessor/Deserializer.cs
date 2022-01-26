namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            List<ImportDepartmentDto> departments = JsonConvert.DeserializeObject<List<ImportDepartmentDto>>(jsonString);

            List<Department> validDepartments = new List<Department>();
            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                if (!IsValid(department) || department.Cells.Length == 0 || department.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department d = new Department()
                {
                    Name = department.Name
                };

                foreach (var cellDto in department.Cells)
                {
                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    };

                    d.Cells.Add(cell);
                }

                validDepartments.Add(d);
                sb.AppendLine(string.Format(SuccessfullyImportedDepartment, d.Name, d.Cells.Count));
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            List<ImportPrisonerDto> prisoners = JsonConvert.DeserializeObject<List<ImportPrisonerDto>>(jsonString);

            List<Prisoner> validPrisoners = new List<Prisoner>();
            StringBuilder sb = new StringBuilder();

            foreach (var prisoner in prisoners)
            {
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);
                bool areMailsValid = prisoner.Mails.All(m => IsValid(m));

                if (!IsValid(prisoner) || !isIncarcerationDateValid || !areMailsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;

                if (prisoner.ReleaseDate != null)
                {
                    releaseDate = DateTime.ParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                }

                Prisoner p = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    Mails = prisoner.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    })
                    .ToList()
                };

                validPrisoners.Add(p);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, p.FullName, p.Age));
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
            ImportOfficerDto[] officers = (ImportOfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Officer> validOfficers = new List<Officer>();

            foreach (var officer in officers)
            {
                bool isPositionValid = Enum.TryParse<Position>(officer.Position, out Position position);
                bool isWeaponValid = Enum.TryParse<Weapon>(officer.Weapon, out Weapon weapon);

                if (!IsValid(officer) || !isPositionValid || !isWeaponValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer o = new Officer()
                {
                    FullName = officer.Name,
                    Salary = officer.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners
                    .Select(p => new OfficerPrisoner() { PrisonerId = p.Id }).ToArray()
                };

                validOfficers.Add(o);
                sb.AppendLine(string.Format(SuccessfullyImportedOfficer, o.FullName, o.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}