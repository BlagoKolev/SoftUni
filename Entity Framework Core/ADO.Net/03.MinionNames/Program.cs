using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var villainId = int.Parse(Console.ReadLine());

            string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true";

            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            var vallainName = GetViliantName(sqlConnection, villainId);

            if (vallainName == null)
            {
                var result = $"No villain with ID {villainId} exists in the database.";
                Console.WriteLine(result);
                return;
            }

          string[] minions =  GetMinionsForVillain(sqlConnection, vallainName).ToArray();

            StringBuilder output = new StringBuilder();

            if (minions.Length == 0)
            {
                output.AppendLine($"Villain: {vallainName}")
                     .AppendLine("(no minions)");
            }
            else
            {
                output.AppendLine($"Villain: {vallainName}");
                for (int i = 0; i < minions.Length; i++)
                {
                    output.AppendLine($"{i + 1}. {minions[i]}");
                }
            }

            Console.WriteLine(output);
        }
        private static string GetViliantName(SqlConnection sqlConnection, int villainId)
        {
            string getVillainNameQuery = @"SELECT [Name] FROM Villains WHERE Id = @villainId";

            using SqlCommand GetViliantNameSqlCommand = new SqlCommand(getVillainNameQuery, sqlConnection);
            GetViliantNameSqlCommand.Parameters.AddWithValue("@villainId", villainId);

            string villainName = GetViliantNameSqlCommand.ExecuteScalar()?.ToString();
            return villainName;
        }

        private static List<string> GetMinionsForVillain(SqlConnection sqlConnection, string villainName)
        {
            string getMinionsQuery = "SELECT m.[Name] AS MinionName, m.Age AS Age" +
                                    " FROM Villains AS v " +
                                "JOIN MinionsVillains As mv  ON mv.VillainId = v.Id " +
                                "JOIN Minions AS m ON mv.MinionId = m.Id WHERE v.Name =             @villainName";

           using SqlCommand getMinionsSqlCommand = new SqlCommand(getMinionsQuery, sqlConnection);

            getMinionsSqlCommand.Parameters.AddWithValue("@villainName", villainName);

            using SqlDataReader reader = getMinionsSqlCommand.ExecuteReader();
            var minionNames = new List<string>();
            while (reader.Read())
            {
                var text = $"{reader["MinionName"]} {reader["Age"]}";
                minionNames.Add((string)text);
            }

            return minionNames;

        }
    }
}
