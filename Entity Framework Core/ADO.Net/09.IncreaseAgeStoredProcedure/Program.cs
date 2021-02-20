using System;
using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {

            int id = int.Parse(Console.ReadLine());

           string connectionString = "Server=.;Database=MinionsDB;Integrated Security = true;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string procedurequery = "CREATE OR ALTER PROC usp_GetOlder @id INT " +
                "AS " +
                "UPDATE Minions SET Age += 1" +
                " WHERE Id = @id ";

            CreateProcedure(procedurequery, sqlConnection);

            Console.WriteLine(GetMinionById(sqlConnection,id));



        }
        private static void CreateProcedure(string queryString, SqlConnection connection)
        {
            SqlCommand createProcedure = new SqlCommand(queryString, connection);
            createProcedure.ExecuteNonQuery();
        }
        private static string GetMinionById(SqlConnection connection, int minionId)
        {

            string queryString = "SELECT Name, Age FROM Minions WHERE Id = @Id";
            SqlCommand getMinion = new SqlCommand(queryString, connection);
            getMinion.Parameters.AddWithValue("@id", minionId);
            SqlDataReader reader = getMinion.ExecuteReader();
            reader.Read();
            string output = $"{reader["Name"]} - {reader["Age"]} years old";
            return output;
        }
    }
}
