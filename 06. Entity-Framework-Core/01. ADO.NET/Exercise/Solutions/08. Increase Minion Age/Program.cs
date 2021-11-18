﻿namespace IncreaseMinionAge
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            
            connection.Open();
            var ids = Inputs();
            Update(connection, ids);
            
            Print(connection);
        }

        private static List<int> Inputs()
        {
            var input = Console.ReadLine().Split();
            var ids = input.Select(int.Parse).ToList();
           
            return ids;
        }

        private static void Update(SqlConnection connection, List<int> ids)
        {
            var query = @"UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 WHERE Id = @Id";
            
            foreach (var id in ids)
            {
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        private static void Print(SqlConnection connection)
        {            
            var query = @"SELECT Name, Age FROM Minions";
            
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0] as string;
                        var age = (int)reader[1];
                        
                        Console.WriteLine($"{name} {age}");
                    }
                }
            }
        }
    }
}