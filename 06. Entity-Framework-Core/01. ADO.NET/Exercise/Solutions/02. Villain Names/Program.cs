namespace VillainNames
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
            Print(connection);
        }

        private static void Print(SqlConnection connection)
        {            
            var query = @"SELECT V.[Name], COUNT(MV.MinionId) as CountOfMinions FROM Villains V JOIN MinionsVillains MV ON MV.VillainId = V.Id 
                            JOIN Minions M ON M.Id = MV.MinionId GROUP BY V.Id, V.[Name] HAVING COUNT(MV.MinionId) > 3 ORDER BY CountOfMinions DESC";
            
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0];
                        var count = reader[1];

                        Console.WriteLine($"{name} - {count}");
                    }
                }
            }
        }
    }
}