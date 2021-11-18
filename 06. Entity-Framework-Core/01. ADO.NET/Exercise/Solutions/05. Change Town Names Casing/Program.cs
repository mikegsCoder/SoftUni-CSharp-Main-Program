﻿namespace ChangeTownNamesCasing
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            var countryName = Console.ReadLine();
            var numberOfTowns = GetNumberOfTowns(connection, countryName);
            
            if (numberOfTowns == 0)
            {
                Console.WriteLine("No town names were affected.");
                
                return;
            }
            
            var listOfTowns = GetListOfTowns(connection, countryName);
            
            Print(numberOfTowns, listOfTowns);
        }

        private static void Print(int numberOfTowns, List<string> listOfTowns)
        {
            Console.WriteLine($"{numberOfTowns} town names were affected.");
            
            var towns = string.Join(", ", listOfTowns);
            
            Console.WriteLine($"[{towns}]");
        }

        private static List<string> GetListOfTowns(SqlConnection connection, string countryName)
        {            
            var query = @"SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";
            
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);
                
                using (var reader = command.ExecuteReader())
                {
                    List<string> listOfTowns = new List<string>();
                    
                    while (reader.Read())
                    {
                        var name = reader[0] as string;
                        listOfTowns.Add(name);
                    }

                    return listOfTowns;
                }
            }
        }

        private static int GetNumberOfTowns(SqlConnection connection, string countryName)
        {
            var query = @"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryName", countryName);
            var numberOfTowns = command.ExecuteNonQuery();
            
            return numberOfTowns;
        }
    }
}