using System;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            var minionInfo = Console.ReadLine().Split();
            var vallainInfo = Console.ReadLine().Split();

            var minionName = minionInfo[1];
            var minionAge = int.Parse(minionInfo[2]);
            var minionTown = minionInfo[3];

            var villainName = vallainInfo[1];

            string connectionString = "Server=.;Database=MinionsDB;Integrated Security = true";

            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string townName = CheckTownInDB(sqlConnection, minionTown);
            
            if (townName == null)
            {
                string townToInsertQuery = "INSERT INTO Towns([Name]) VALUES (@minionTown)";
                using SqlCommand insertTown = new SqlCommand(townToInsertQuery, sqlConnection);
                insertTown.Parameters.AddWithValue("@minionTown", minionTown);
                insertTown.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            string chekedName = CheckVillainName(sqlConnection, villainName);

            if (chekedName == null)
            {
                string insertVillainQuery = "INSERT INTO Villains VALUES (@villainName,4)";
                using SqlCommand insertVillain = new SqlCommand(insertVillainQuery, sqlConnection);
                insertVillain.Parameters.AddWithValue("@villainName", villainName);
                insertVillain.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            string searchedMinion = CheckMinionInDB(sqlConnection, minionName);

            if (searchedMinion == null)
            {
                int townId = GetTownId(sqlConnection, minionTown);
                string insertMinionQuery = "INSERT INTO [Minions] VALUES (@minionName, @minionAge, @townId)";
                using SqlCommand insertMinionToDB = new SqlCommand(insertMinionQuery, sqlConnection);
                insertMinionToDB.Parameters.AddWithValue("@minionName", minionName);
                insertMinionToDB.Parameters.AddWithValue("@minionAge", minionAge);
                insertMinionToDB.Parameters.AddWithValue("@townId", townId);

                insertMinionToDB.ExecuteNonQuery();
            }

            int? minionId = GetMinionId(sqlConnection, minionName);
            int? villainId = GetVillainId(sqlConnection, villainName);

            InsertIntoMinionsVillains(sqlConnection, minionId, villainId);
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

        }
        private static string CheckTownInDB(SqlConnection connection, string townName)
        {
            string sqlQuery = @"SELECT [Name] FROM Towns WHERE [Name] = @townName";
            using SqlCommand getTown = new SqlCommand(sqlQuery, connection);
            getTown.Parameters.AddWithValue("@townName", townName);

            string town = getTown.ExecuteScalar()?.ToString();
         
            return town;
        }

        private static string CheckVillainName(SqlConnection connection, string villainName)
        {
            string sqlQuery = "SELECT [Name] FROM [Villains] WHERE [Name] = @villainName";
            using SqlCommand getName = new SqlCommand(sqlQuery, connection);
            getName.Parameters.AddWithValue("@villainName", villainName);
            string name = getName.ExecuteScalar()?.ToString();
            return name;
        }

        private static string CheckMinionInDB(SqlConnection connection, string minionName)
        {
            string getMinionQuery = "SELECT [Name] FROM Minions WHERE [Name] = @minionName";
            using SqlCommand getMinionName = new SqlCommand(getMinionQuery, connection);
            getMinionName.Parameters.AddWithValue("@minionName", minionName);
            string name = getMinionName.ExecuteScalar()?.ToString();
            return name;
        }

        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            string getMinionIdQuery = "SELECT [Id] FROM Minions WHERE [Name] = @minionName";
            using SqlCommand getMinionId = new SqlCommand(getMinionIdQuery, connection);
            getMinionId.Parameters.AddWithValue("@minionName", minionName);

            int? id = (int)getMinionId.ExecuteScalar();
            return id;
        }

        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            string getMinionIdQuery = "SELECT [Id] FROM Villains WHERE [Name] = @villainName";
            using SqlCommand getVillainId = new SqlCommand(getMinionIdQuery, connection);
            getVillainId.Parameters.AddWithValue("@villainName", villainName);

            int? id = (int)getVillainId.ExecuteScalar();
            return id;
        }

        private static void InsertIntoMinionsVillains(SqlConnection connection,int? minionId, int? villainId)
        {
            string insertIntoQuery = "INSERT INTO MinionsVillains VALUES (@minionId,@villainId)";
            using SqlCommand insertIntoDB = new SqlCommand(insertIntoQuery, connection);
            insertIntoDB.Parameters.AddWithValue("@minionId",minionId);
            insertIntoDB.Parameters.AddWithValue("@villainId",villainId);
            insertIntoDB.ExecuteNonQuery();
        }

        private static int GetTownId(SqlConnection connection, string townName)
        {
            string getTownIdQuery = "SELECT Id FROM Towns WHERE [Name] = @townName";
            using SqlCommand getTownId = new SqlCommand(getTownIdQuery, connection);
            getTownId.Parameters.AddWithValue("@townName", townName);
            int id = (int)getTownId.ExecuteScalar();
            return id;
        }
    }
}
