namespace IncreaseAgeStoredProc
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Data;

    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            var id = int.Parse(Console.ReadLine());
                        
            ExecProc(id, connection);
            Print(connection, id);
        }

        private static void Print(SqlConnection connection, int id)
        {          
            var query = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0] as string;
                        var age = (int)reader[1];
                        
                        Console.WriteLine($"{name} – {age} years old");
                    }
                }
            }
        }

        private static void ExecProc(int id, SqlConnection connection)
        {
            string query = @$"EXEC usp_GetOlder {id}";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        private static void CreateProc(int id, SqlConnection connection)
        {
            string query = @"CREATE OR ALTER PROC usp_GetOlder @id INT AS UPDATE Minions SET Age += 1 WHERE Id = @id";
            using var command = new SqlCommand(query, connection);
            
            command.CommandText = "usp_GetOlder";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}