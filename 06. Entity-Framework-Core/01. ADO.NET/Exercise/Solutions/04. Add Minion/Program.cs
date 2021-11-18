namespace AddMinion
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Linq;

    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            var minionName = ReadInputs(out var minionAge, out var minionTownName, out var villainName);
            var townId = GetTownId(connection, minionTownName);
            townId = IfTownIdNotExists(townId, connection, minionTownName);
            var villainId = GetVillainId(connection, villainName);
            villainId = IfVillainIdNotExists(villainId, connection, villainName);
            var minionId = GetMinionId(connection, minionName);
            minionId = IfMinionIdNotExists(minionId, connection, minionName, minionAge, townId);
            InsertIntoMinionsVillains(connection, villainId, minionId, minionName, villainName);
        }

        private static void InsertIntoMinionsVillains(SqlConnection connection, object villainId, object minionId, string minionName, string villainName)
        {
            var query = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainId", villainId);
            command.Parameters.AddWithValue("@minionId", minionId);
            command.ExecuteNonQuery();
            
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static object IfMinionIdNotExists(object minionId, SqlConnection connection, string minionName, int minionAge, object townId)
        {
            if (minionId == null)
            {
                InsertMinion(connection, minionName, minionAge, townId);
                minionId = GetMinionId(connection, minionName);
            }

            return minionId;
        }

        private static void InsertMinion(SqlConnection connection, string minionName, int minionAge, object townId)
        {
            var query = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", minionName);
            command.Parameters.AddWithValue("@age", minionAge);
            command.Parameters.AddWithValue("@townId", (int)townId);
            command.ExecuteNonQuery();
        }

        private static object GetMinionId(SqlConnection connection, string minionName)
        {
            var query = "SELECT Id FROM Minions WHERE Name = @Name";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", minionName);
            var minionId = command.ExecuteScalar();

            return minionId;
        }

        private static object IfVillainIdNotExists(object villainId, SqlConnection connection, string villainName)
        {
            if (villainId == null)
            {
                InsertVillain(connection, villainName);
                villainId = GetVillainId(connection, villainName);
            }

            return villainId;
        }

        private static void InsertVillain(SqlConnection connection, string villainName)
        {
            var query = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainName", villainName);
            command.ExecuteNonQuery();
            
            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static object GetVillainId(SqlConnection connection, string villainName)
        {
            var query = @"SELECT Id FROM Villains WHERE Name = @Name";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", villainName);
            var villainId = command.ExecuteScalar();
            
            return villainId;
        }

        private static object IfTownIdNotExists(object townId, SqlConnection connection, string minionTownName)
        {
            if (townId == null)
            {
                InsertTown(connection, minionTownName);
                townId = GetTownId(connection, minionTownName);
            }

            return townId;
        }

        private static void InsertTown(SqlConnection connection, string minionTownName)
        {
            var query = "INSERT INTO Towns (Name) VALUES (@townName)";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@townName", minionTownName);
            command.ExecuteNonQuery();
            
            Console.WriteLine($"Town {minionTownName} was added to the database.");
        }

        private static object GetTownId(SqlConnection connection, string minionTownName)
        {
            var query = @"SELECT Id FROM Towns WHERE Name = @townName";
            
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@townName", minionTownName);
            var townId = command.ExecuteScalar();
            
            return townId;
        }

        private static string ReadInputs(out int minionAge, out string minionTownName, out string villainName)
        {
            var minionInfo = Console.ReadLine().Split().ToArray();
            var minionName = minionInfo[1];
            minionAge = int.Parse(minionInfo[2]);
            minionTownName = minionInfo[3];
            villainName = Console.ReadLine().Split().ToArray()[1];
            
            return minionName;
        }
    }
}