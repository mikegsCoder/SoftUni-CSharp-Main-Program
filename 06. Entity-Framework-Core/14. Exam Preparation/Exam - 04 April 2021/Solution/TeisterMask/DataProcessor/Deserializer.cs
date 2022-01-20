namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static bool IsNullOrWhitespace { get; private set; }

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
            ImportProjectDto[] projects = (ImportProjectDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            List<Project> validProjects = new List<Project>();

            foreach (var project in projects)
            {
                bool isDateValid = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDate);

                if (!IsValid(project) || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (project.DueDate != null)
                {
                    dueDate = DateTime.ParseExact(project.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                Project p = new Project()
                {
                    Name = project.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                foreach (var taskDto in project.Tasks)
                {
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);
                    bool isExecutionTypeValid = taskDto.ExecutionType >= 0 && taskDto.ExecutionType <= 3;
                    bool isLabelTypeValid = taskDto.LabelType >= 0 && taskDto.LabelType <= 4;

                    if (!IsValid(taskDto) 
                        || !isTaskOpenDateValid 
                        || !isTaskDueDateValid
                        || !isExecutionTypeValid 
                        || !isLabelTypeValid
                        || taskOpenDate < p.OpenDate
                        || ( p.DueDate.HasValue && taskDueDate > p.DueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    p.Tasks.Add(t);
                }

                validProjects.Add(p);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, p.Name, p.Tasks.Count));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            List<ImportEmployeeDto> employees = JsonConvert.DeserializeObject<List<ImportEmployeeDto>>(jsonString);

            List<Employee> validEmployees = new List<Employee>();
            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                if (!IsValid(employee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee e = new Employee()
                {
                    Username = employee.Username,
                    Email = employee.Email,
                    Phone = employee.Phone,                    
                };

                foreach (var taskId in employee.Tasks.Distinct())
                {
                    Task t = context.Tasks.FirstOrDefault(x => x.Id == taskId);

                    if (t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    e.EmployeesTasks.Add(new EmployeeTask() { Task = t });
                }

                validEmployees.Add(e);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, e.Username, e.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}