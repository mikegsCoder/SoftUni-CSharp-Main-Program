using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace PrintAllMinionNames
{
    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            
            connection.Open();
            var minionNames = Names(connection);
            
            Print(minionNames);
        }

        private static void Print(List<string> names)
        {
            for (int i = 1; i <= Math.Ceiling(names.Count / 2.0); i++)
            {
                Console.WriteLine(names[i - 1]);

                if (i == names.Count / 2 + 1 && names.Count % 2 == 1)
                {
                    continue;
                }

                Console.WriteLine(names[^i]);
            }
        }

        private static List<string> Names(SqlConnection connection)
        {            
            var query = @"SELECT Name FROM Minions";
            
            using (var sqlCommand = new SqlCommand(query, connection))
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    var names = new List<string>();
                    
                    while (reader.Read())
                    {
                        var name = reader[0] as string;
                        names.Add(name);
                    }

                    return names;
                }
            }
        }
    }
}