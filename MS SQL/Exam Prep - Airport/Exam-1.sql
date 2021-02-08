CREATE DATABASE [Airport]

USE [Airport]


CREATE TABLE [Planes] (
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
[Seats] INT NOT NULL,
[Range] INT NOT NULL
)

CREATE TABLE [Flights] (
[Id] INT PRIMARY KEY IDENTITY,
[DepartureTime] DATETIME2,
[ArrivalTime] DATETIME2,
[Origin] VARCHAR(50) NOT NULL,
[Destination] VARCHAR(50) NOT NULL,
[PlaneId] INT NOT NULL FOREIGN KEY REFERENCES [Planes]([Id])
)

CREATE TABLE [Passengers] (
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(30) NOT NULL,
[LastName] VARCHAR(30) NOT NULL,
[Age] INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
[PassportId] CHAR(11) NOT NULL 
)

CREATE TABLE [LuggageTypes] (
[Id] INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(30) NOT NULL
)


CREATE TABLE [Luggages] (
[Id] INT PRIMARY KEY IDENTITY,
[LuggageTypeId] INT NOT NULL FOREIGN KEY REFERENCES [LuggageTypes]([Id]),
[PassengerId] INT NOT NULL FOREIGN KEY REFERENCES [Passengers]([Id])
)

CREATE TABLE  Tickets (
[Id] INT PRIMARY KEY IDENTITY,
[PassengerId] INT FOREIGN KEY REFERENCES Passengers([Id]) NOT NULL,
[FlightId] INT FOREIGN KEY REFERENCES [Flights]([Id]) NOT NULL,
[LuggageId] INT FOREIGN KEY REFERENCES [Luggages]([Id]) NOT NULL,
[Price] DECIMAL(15,2) NOT NULL
)


--**************************************************************************************
-- PROBLEM 2 - Insert

INSERT INTO [Planes]([Name], [Seats], [Range])
VALUES
('Airbus 336',112 ,5132),
('Airbus 330',432 ,5325),
('Boeing 369',231 ,2355),
('Stelt 297',254 ,2143),
('Boeing 338',165 ,5111),
('Airbus 558',387 ,1342),
('Boeing 128',345 ,5541)

INSERT INTO [LuggageTypes]
VALUES ('Crossbody Bag'),('School Backpack'),('Shoulder Bag')


--**************************************************************************************
-- PROBLEM 3 - Update

UPDATE [Tickets] SET [Price] += [Price] * 0.13
WHERE [Id] IN (SELECT t.[Id] FROM [Flights] AS f
JOIN [Tickets] AS t ON f.Id = t.FlightId
WHERE f.[Destination] = 'Carlsbad')

--**************************************************************************************
-- PROBLEM 4 - Delete

DELETE FROM [Tickets]
WHERE [Id] IN (SELECT t.[Id] FROM [Flights] AS f
JOIN [Tickets] AS t ON f.Id = t.FlightId
WHERE f.[Destination] = 'Ayn Halagim')

DELETE FROM [Flights]
WHERE [Destination] = 'Ayn Halagim'


--**************************************************************************************
-- PROBLEM 5 - The "Tr" Planes

SELECT * FROM [Planes] 
WHERE [Name] LIKE '%tr%'
ORDER BY [Id], [Name], [Seats], [Range]

--**************************************************************************************
-- PROBLEM 6 - Flight Profits

SELECT f.[Id] AS [FlightId], SUM(t.[Price]) AS [Price] FROM [Flights] AS f
JOIN [Tickets] AS t ON f.Id = t.FlightId
GROUP BY  f.[Id]
ORDER BY [Price] DESC , f.[Id]


--**************************************************************************************
-- PROBLEM 7 - Passenger Trips

SELECT p.[FirstName] + ' ' + p.[LastName] As [Full Name], f.[Origin], f.[Destination]  FROM [Passengers] AS p
JOIN [Tickets] AS t ON p.[Id] = t.PassengerId
JOIN [Flights] AS f ON t.FlightId = f.[Id]
ORDER BY [Full Name],  f.[Origin], f.[Destination]


--**************************************************************************************
-- PROBLEM - 8 - Non Adventures People

SELECT p.[FirstName], p.[LastName], p.[Age] FROM [Passengers] as p
LEFT JOIN [Tickets] AS t ON p.[Id] = t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.[Age] DESC, p.[FirstName], p.[LastName]



--**************************************************************************************
-- PROBLEM - 9 - Full Info

SELECT (p.[FirstName] + ' ' + p.[LastName]) AS [Full Name],pl.[Name] AS [Plane Name],
(f.Origin + ' - ' + f.Destination) AS [Trip], lt.[Type] AS [Luggage Type] 
FROM [Passengers] AS p
JOIN [Tickets] As t ON p.Id = t.PassengerId
JOIN [Flights] AS f ON t.[FlightId] = f.Id
JOIN [Planes] AS pl ON f.[PlaneId] = pl.[Id]
JOIN [Luggages] AS l ON t.[LuggageId] = l.Id
JOIN [LuggageTypes] AS lt ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]


--**************************************************************************************
-- PROBLEM - 10 - PSP


SELECT pl.[Name], pl.[Seats], COUNT(p.Id) AS [Passengers Count] FROM [Planes] AS pl
LEFT JOIN [Flights] AS f ON pl.Id = f.PlaneId
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
LEFT JOIN [Passengers] AS p ON t.PassengerId = p.[Id]
GROUP BY pl.[Name], pl.Seats
ORDER BY [Passengers Count] DESC , pl.[Name], pl.[Seats]


--**************************************************************************************
-- PROBLEM - 11 - Vacation

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(100)
AS
	BEGIN
		

		IF(@peopleCount <= 0)
		BEGIN
			RETURN  'Invalid people count!'
		END

		DECLARE @flight INT = (SELECT f.[Id] FROM [Flights] AS f
		JOIN [Tickets] As t ON f.Id = t.FlightId
		WHERE [Origin] = @origin 
		AND [Destination] = @destination)

		IF(@flight IS NULL)
			BEGIN
				RETURN	'Invalid flight!'
			END

		DECLARE @price DECIMAL(15,2) = (SELECT t.[Price] FROM [Flights] AS f
								JOIN Tickets AS t ON f.Id = t.FlightId
							 WHERE [Origin] = @origin
		AND [Destination] = @destination)
		
		DECLARE @totalCost DECIMAL(15,2) = @price * @peopleCount

		RETURN 'Total price ' + CAST(@totalCost as VARCHAR(30));
		 
	END


--**************************************************************************************
-- PROBLEM - 12 - Wrong Data

CREATE PROCEDURE usp_CancelFlights
AS
	UPDATE [Flights] SET [ArrivalTime] = NULL ,DepartureTime = NULL
	WHERE  ArrivalTime > DepartureTime
	
		
