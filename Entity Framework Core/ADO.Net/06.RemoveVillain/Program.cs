using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace _06.RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=MinionsDB;Integrated security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            int villainId = int.Parse(Console.ReadLine());
            string villainName = CheckIfVillainExists(sqlConnection, villainId);
            if (villainName == null)
            {
                Console.WriteLine("No such villain was found");
                return;
            }

            StringBuilder output = new StringBuilder();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                int minionsCount = GetMinionsCount(sqlConnection, villainId, sqlTransaction);
                DeleteFromRefTable(sqlConnection, villainId, sqlTransaction);
                DeleteVillainById(sqlConnection, villainId, sqlTransaction);
                sqlTransaction.Commit();
                output.AppendLine($"{villainName} was deleted")
    .AppendLine($"{minionsCount} minions were released");
            }
            catch (Exception ex)
            {

                output.AppendLine(ex.Message);
                try
                {
                    sqlTransaction.Rollback();
                }
                catch (Exception rollEx)
                {
                    output.AppendLine(rollEx.Message);
                    throw;
                }
            }
            Console.WriteLine(output);
        }
        private static string CheckIfVillainExists(SqlConnection connection, int villainId)
        {
            string stringQuery = "SELECT [Name] FROM Villains WHERE Id = @villainId";
            using SqlCommand getName = new SqlCommand(stringQuery, connection);
            getName.Parameters.AddWithValue("@villainId", villainId);

            string name = getName.ExecuteScalar()?.ToString();
            return name;
        }
        private static int GetMinionsCount(SqlConnection connection, int villainId, SqlTransaction sqlTransaction)
        {
            string queryString = "SELECT COUNT(*) FROM MinionsVillains WHERE VillainId = @villainId";
            using SqlCommand getMinions = new SqlCommand(queryString, connection);
            getMinions.Parameters.AddWithValue("@villainId", villainId);
            getMinions.Transaction = sqlTransaction;

            int count = (int)getMinions.ExecuteScalar();

            return count;
        }

        private static void DeleteFromRefTable(SqlConnection connection, int villainId, SqlTransaction sqlTransaction)
        {
            string queryString = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
            using SqlCommand deleteVillain = new SqlCommand(queryString, connection);
            deleteVillain.Parameters.AddWithValue("@villainId", villainId);
            deleteVillain.Transaction = sqlTransaction;

            deleteVillain.ExecuteNonQuery();
        }

        private static void DeleteVillainById(SqlConnection connection, int villainId, SqlTransaction sqlTransaction)
        {
            string queryString = "DELETE FROM Villains WHERE Id = @villainId";
            using SqlCommand deleteVillain = new SqlCommand(queryString, connection);
            deleteVillain.Parameters.AddWithValue("@villainId", villainId);
            deleteVillain.Transaction = sqlTransaction;
            deleteVillain.ExecuteNonQuery();
        }
    }
}
