using System;
using Microsoft.Data.SqlClient;

namespace VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string command = @"SELECT v.[Name], COUNT(m.[Name]) AS [Count]
                                 FROM [MinionsVillains] AS mv 
                                JOIN[Minions] AS m ON mv.MinionId = m.Id
                                JOIN[Villains] As v ON mv.VillainId = v.Id 
                                GROUP BY v.Name 
                                HAVING COUNT(m.[Name]) > 3 
                                ORDER BY COUNT(m.[Name]) DESC";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
             
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        int count = (int)reader["Count"];
                        Console.WriteLine($"{name} - {count}");
                       
                    }
                }
            };


        }
    }
}
