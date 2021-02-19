using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
           var  countryName = Console.ReadLine();

            string connectionString = "Server=.;Database=MinionsDB;Integrated Security = true;";
          using  SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            int countryId = GetCountryId(sqlConnection, countryName);

                         
            if (countryId == -1)
            {
                Console.WriteLine($"{countryName} does not exist in Database");
                return;
            }
           
           
              string[] towns = GetTownsForCountry(sqlConnection, countryId);
            

            StringBuilder output = new StringBuilder();

            if (towns.Length ==0)
            {
                output.AppendLine("No town names were affected.");
            }
            else
            {
                output.AppendLine($"{towns.Length} town names were affected");
                output.AppendLine(string.Join(", ", towns));
            }

            Console.WriteLine(output);

        }
        private static int GetCountryId(SqlConnection connection, string countryName)
        {
            string getCountryIdQuery = "SELECT [Id] FROM Countries WHERE [Name] = @countryName";
            using SqlCommand getCountryId = new SqlCommand(getCountryIdQuery, connection);
            getCountryId.Parameters.AddWithValue("@countryName", countryName);
            string countryId = getCountryId.ExecuteScalar()?.ToString();
            int result;
            bool isInt = int.TryParse(countryId, out result);
            if (isInt)
            {
                return result;
            }
            return -1;
        }
        private static string[] GetTownsForCountry(SqlConnection connection, int countryId)
        {
            string getTownNamesQuery = "SELECT [Name] FROM Towns WHERE [CountryCode] = @countryId";
            string changeTownToUpperQuery = "UPDATE [Towns] SET [Name] = UPPER([Name]) FROM Towns WHERE [CountryCode] = @countryId";

            using SqlCommand getTownNames = new SqlCommand(getTownNamesQuery,connection);
            using SqlCommand changeTownToUpper = new SqlCommand(changeTownToUpperQuery, connection);
            getTownNames.Parameters.AddWithValue("@countryId", countryId);
            changeTownToUpper.Parameters.AddWithValue("@countryId", countryId);
            changeTownToUpper.ExecuteNonQuery();

            List<string> towns = new List<string>();

            using SqlDataReader reader = getTownNames.ExecuteReader();
         
            
            while (reader.Read())
            {
                towns.Add((string)reader["Name"]);
            }
         return towns.ToArray();   
        }
    }
}
