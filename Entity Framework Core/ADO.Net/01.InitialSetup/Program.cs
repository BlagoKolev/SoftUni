using System;
using Microsoft.Data.SqlClient;

namespace _01.InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database={0};Integrated Security = true;";

            using SqlConnection sqlConnection = new SqlConnection(String.Format(connectionString, "master"));

            sqlConnection.Open();

            CreateDatabase(sqlConnection);

            using SqlConnection connection = new SqlConnection(String.Format(connectionString, "MinionsDB"));
            connection.Open();
            //CREATE TABLES
            string countriesQuery = "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))";
            CreateTable(countriesQuery, connection);

            string townQuery = "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
            CreateTable(townQuery, connection);

            string minionsQuery = "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";
            CreateTable(minionsQuery, connection);

            string evilnessQuery = "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
            CreateTable(evilnessQuery, connection);

            string villainsQuery = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
            CreateTable(villainsQuery, connection);

            string mappingTable = "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
            CreateTable(mappingTable, connection);

            //INSERT INTO TABLES
            string insertCountries = "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";
            InsertIntoTable(insertCountries, connection);

            string insertTowns = "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";
            InsertIntoTable(insertTowns, connection);

            string insertMinions = "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";
            InsertIntoTable(insertMinions, connection);


            string insertEvilness = "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
            InsertIntoTable(insertEvilness, connection);

            string insertVillains = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)";
            InsertIntoTable(insertVillains, connection);

            string insertMappingTable = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";
            InsertIntoTable(insertMappingTable, connection);

        }
        private static void CreateDatabase(SqlConnection connection)
        {
            string createQuery = "CREATE DATABASE MinionsDB";
            SqlCommand createDB = new SqlCommand(createQuery, connection);
            createDB.ExecuteNonQuery();
        }

        private static void CreateTable(string queryString, SqlConnection connection)
        {
            SqlCommand createTable = new SqlCommand(queryString, connection);
            createTable.ExecuteNonQuery();
        }

        private static void InsertIntoTable(string insertionString,SqlConnection connection)
        {
            SqlCommand insertIntoTable = new SqlCommand(insertionString, connection);
            insertIntoTable.ExecuteNonQuery();
        }
    }
}
