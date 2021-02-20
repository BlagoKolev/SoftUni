using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=MinionsDB;Integrated Security = true;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string queryString = "SELECT [Name] FROM Minions";
            using SqlCommand getMinions = new SqlCommand(queryString, sqlConnection);

           using SqlDataReader reader = getMinions.ExecuteReader();

            List<string> minions = new List<string>();

            while (reader.Read())
            {
                minions.Add((string)reader["Name"]);
            }

            if (minions.Count%2 == 0 )
            {
                for (int i = 0; i < minions.Count / 2; i++)
                {
                    Console.WriteLine(minions[i]);
                   
                    Console.WriteLine(minions[minions.Count - 1 - i]);
                }
            }
            else
            {
                for (int i = 0; i <= minions.Count / 2 ; i++)
                {
                    Console.WriteLine(minions[i]);
                    if (i == minions.Count/2)
                    {
                        break;
                    }
                    Console.WriteLine(minions[minions.Count - 1 - i]);
                }
            }
           
        }
    }
}
