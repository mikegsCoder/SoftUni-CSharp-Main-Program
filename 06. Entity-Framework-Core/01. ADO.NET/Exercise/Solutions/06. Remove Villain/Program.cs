﻿namespace RemoveVillain
{
    using Microsoft.Data.SqlClient;
    using System;

    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            
            connection.Open();
            var villainId = int.Parse(Console.ReadLine());
            var villainName = GetVillainName(connection, villainId);
            
            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");
                
                return;
            }

            var releasedMinions = ReleasesMinions(connection, villainId, 1);
            ReleasesMinions(connection, villainId, 2);
            
            Print(releasedMinions);
        }

        private static void Print(int releasedMinions)
        {
            Console.WriteLine($"{releasedMinions} minions were released.");
        }

        private static int ReleasesMinions(SqlConnection connection, int villainId, int tableNumber)
        {
            var query = tableNumber switch
            {
                1 => @"DELETE FROM MinionsVillains WHERE VillainId = @villainId",
                2 => @"DELETE FROM Villains WHERE Id = @villainId",
                _ => null
            };

            using var command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@villainId", villainId);
            var releasesMinions = command.ExecuteNonQuery();
            
            return releasesMinions;
        }

        private static object GetVillainName(SqlConnection connection, int villainId)
        {
            var query = @"SELECT Name FROM Villains WHERE Id = @villainId";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainId", villainId);
            var villainName = command.ExecuteScalar();
            
            return villainName;
        }
    }
}