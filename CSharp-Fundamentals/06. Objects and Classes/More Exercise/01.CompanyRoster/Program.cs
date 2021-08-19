using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Rosted
{
    class Program
    {
        static void Main()
        {
            // READ INPUT

            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<Employee> listOfEmployees = new List<Employee>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                double salary = double.Parse(input[1]);
                string dep = input[2];

                var newEmployee = new Employee(name, salary, dep);

                listOfEmployees.Add(newEmployee);
            }

            //CALCULATE THE HIGHEST AVERAGE SALARY

            listOfEmployees = listOfEmployees.OrderBy(x => x.Department).ToList();

            var departments = new Dictionary<string, List<double>>();


            for (int i = 0; i < listOfEmployees.Count; i++)
            {
                string newDepartment = listOfEmployees[i].Department;
                double newSlary = listOfEmployees[i].Salary;
                if (!departments.ContainsKey(newDepartment))
                {
                    departments[newDepartment] = new List<double>();
                }
                departments[newDepartment].Add(newSlary);
            }
            string departmentMaxAverage = departments.OrderByDescending(x => x.Value.Average()).First().Key;

            //PRINT OUTPUT

            listOfEmployees = listOfEmployees
                .Where(x => x.Department == departmentMaxAverage)
                .OrderByDescending(x => x.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {departmentMaxAverage}");

            foreach (var men in listOfEmployees)
            {
                Console.WriteLine($"{men.Name} {men.Salary:f2}");
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
    }
}