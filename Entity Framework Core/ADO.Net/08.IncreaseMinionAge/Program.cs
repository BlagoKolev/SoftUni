using System;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] minionsId = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string connectionString = "Server=.;Database=MinionsDB;Integrated Security = true;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            UpdateMinionsAgeAndName(sqlConnection, minionsId);

            PrintUpdatedMinions(sqlConnection);

        }
        private static void UpdateMinionsAgeAndName(SqlConnection connection, int[] minionsId)
        {
            string queryString = "UPDATE Minions SET Age +=1 WHERE [Id] = @minionId";
            using SqlCommand changeAge = new SqlCommand(queryString, connection);

            changeAge.Parameters.Add("@minionId", System.Data.SqlDbType.Int);
            foreach (var minion in minionsId)
            {
                changeAge.Parameters["@minionId"].Value = minion;
                changeAge.ExecuteNonQuery();
            }

            string getNamesQuery = "SELECT [Name] FROM Minions WHERE [Id] = @minionId";
            using SqlCommand changeNameToTitleCase = new SqlCommand(getNamesQuery, connection);

            changeNameToTitleCase.Parameters.Add("@minionId", System.Data.SqlDbType.Int);

            foreach (var minion in minionsId)
            {

                changeNameToTitleCase.Parameters["@minionId"].Value = minion;
                string currentName = (string)changeNameToTitleCase.ExecuteScalar();

                string[] names = currentName.Split();
                StringBuilder newName = new StringBuilder();

                for (int i = 0; i < names.Length; i++)
                {
                    string partName = names[i];
                    string fLetter = partName.Substring(0, 1);
                    string newLetter = partName.Substring(0, 1).ToUpper();
                    partName = partName.Remove(0, 1).Insert(0, newLetter);

                    if (i >= 1)
                    {
                        newName.Append($" {partName}");
                    }
                    else
                    {
                        newName.Append($"{partName}");
                    }
                }

                string updateNameQuery = "UPDATE [Minions] SET [Name] = @newName WHERE Id = @minionId";
                using SqlCommand updateNameInDB = new SqlCommand(updateNameQuery, connection);

                updateNameInDB.Parameters.Add("@newName", System.Data.SqlDbType.VarChar);
                updateNameInDB.Parameters.Add("@minionId", System.Data.SqlDbType.Int);
                updateNameInDB.Parameters["@newName"].Value = newName.ToString();
                updateNameInDB.Parameters["@minionId"].Value = minion;

                updateNameInDB.ExecuteNonQuery();

            }

        }

        private static void PrintUpdatedMinions(SqlConnection connection)
        {
            string queryString = "SELECT [Name], [Age] FROM Minions";
            using SqlCommand getMinions = new SqlCommand(queryString, connection);

            using SqlDataReader reader = getMinions.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }
        }
    }
}
