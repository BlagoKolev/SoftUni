CREATE DATABASE [ColonialJourney]


USE [ColonialJourney]


CREATE TABLE [Planets](
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL);


CREATE TABLE [Spaceports](
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[PlanetId] INT FOREIGN KEY REFERENCES [Planets]([Id]));

--drop table Planets
--drop table [Spaceports]


CREATE TABLE [Spaceships](
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Manufacturer] VARCHAR(30) NOT NULL,
[LightSpeedRate] INT DEFAULT 0
);

CREATE TABLE [Journeys](
[Id] INT PRIMARY KEY IDENTITY,
[JourneyStart] DATETIME2 NOT NULL,
[JourneyEnd] DATETIME2 NOT NULL,
[Purpose] VARCHAR(11) CHECK ([Purpose] IN ( 'Medical','Technical','Educational','Military')),
[DestinationSpaceportId] INT FOREIGN KEY REFERENCES [Spaceports]([Id]) NOT NULL,
[SpaceshipId] INT  FOREIGN KEY REFERENCES [Spaceships]([Id])
);


CREATE TABLE [Colonists](
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(20) NOT NULL,
[LastName] VARCHAR(20) NOT NULL,
[Ucn] VARCHAR(12) NOT NULL UNIQUE,
[BirthDate] DATE NOT NULL
);
--DROP TABLE [Colonist]


CREATE TABLE [TravelCards] (
[Id] INT PRIMARY KEY IDENTITY,
[CardNumber] VARCHAR(10)  NOT NULL UNIQUE CHECK(LEN([CardNumber]) = 10),
[JobDuringJourney] VARCHAR(8) CHECK([JobDuringJourney] IN ('Pilot','Engineer','Trooper','Cleaner','Cook')),
[ColonistId] INT FOREIGN KEY REFERENCES [Colonists]([Id]) NOT NULL,
[JourneyId] INT FOREIGN KEY REFERENCES [Journeys]([Id]) NOT NULL
);

--*************************************************************************************************
--PROBLEM - 2

INSERT INTO [Planets]
VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO [SpaceShips]
VALUES 
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9', 'SpaceX', 1),
('Bed', 'Vidolov', 6)


--*************************************************************************************************
-- PROBLEM - 3
Select * from Spaceships
UPDATE [Spaceships]
SET [LightSpeedRate] = [LightSpeedRate] + 1
WHERE [Id] >=8 AND [Id] <= 12


--*************************************************************************************************
-- PROBLEM - 4

DELETE FROM [TravelCards]
WHERE [JourneyId] IN (1,2,3)
DELETE FROM [Journeys]
WHERE [Id] IN (1,2,3)

--*************************************************************************************************
-- PROBLEM - 5

SELECT [Id], convert(varchar, [JourneyStart], 103) AS [JourneyStart],convert(varchar, [JourneyEnd], 103) AS [JourneyEnd] FROM [Journeys]
WHERE [Purpose] LIKE 'Military'
ORDER BY [JourneyStart]


--*************************************************************************************************
-- PROBLEM - 6

SELECT c.[Id] AS [id], ([FirstName]+ ' ' +[LastName]) AS [full_name] FROM [Colonists] AS c
JOIN [TravelCards] AS tc ON tc.ColonistId = c.[Id]
WHERE tc.JobDuringJourney = 'pilot'
ORDER BY c.[Id] 



--*************************************************************************************************
-- PROBLEM - 7

SELECT COUNT(c.[Id]) AS [count] FROM [Colonists] AS c
JOIN [TravelCards] AS tc ON tc.[Id] = c.[Id]
WHERE tc.JobDuringJourney = 'engineer'

--*************************************************************************************************
-- PROBLEM - 8
SELECT ss.[Name],ss.[Manufacturer] FROM [TravelCards] as tc
JOIN [Journeys] AS j ON j.Id = tc.JourneyId
JOIN [Spaceships] AS ss ON ss.Id = j.SpaceshipId
JOIN [Colonists] AS c ON c.Id = tc.ColonistId
WHERE c.[BirthDate] > '1989-01-01' AND tc.JobDuringJourney = 'Pilot'
ORDER BY [Name];


--*************************************************************************************************
-- PROBLEM - 9

SELECT p.[Name], COUNT(j.[DestinationSpaceportId]) AS [JourneysCount] FROM [Planets] AS p
JOIN [Spaceports] AS sp ON sp.[PlanetId] = p.[Id]
JOIN [Journeys] AS j ON j.[DestinationSpaceportId] = sp.[Id]
GROUP BY p.[Name] 
ORDER BY [JourneysCount] DESC,p.[Name]

--*************************************************************************************************
-- PROBLEM - 10
SELECT [JobDuringJourney], [FullName], [JobRank] FROM (
SELECT [JobDuringJourney],([FirstName] + ' '+[LastName]) AS [FullName],
DENSE_RANK() OVER (PARTITION BY tc.[JobDuringJourney] ORDER BY c.[BirthDate]) AS [JobRank]
FROM [TravelCards] AS tc
JOIN [Colonists] AS c ON c.Id = tc.[ColonistId]) AS [x]
WHERE [JobRank] =2



--*************************************************************************************************
-- PROBLEM - 11

CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR(30))
	RETURNS INT
	AS
		BEGIN

	DECLARE @count INT = 0

		SELECT @count = COUNT(c.Id) FROM [TravelCards] AS tc
		JOIN [Journeys] AS j ON j.Id = tc.JourneyId
		JOIN [SpacePorts] AS sp ON sp.Id = j.DestinationSpaceportId
		JOIN [Planets] AS p ON p.Id = sp.[PlanetId]
		JOIN [Colonists] AS c ON c.Id = tc.ColonistId
		WHERE p.Name = @PlanetName
		
		RETURN @count
	END


	--SELECT  dbo.udf_GetColonistsCount('Otroyphus') AS [Count]

SELECT * FROM [Spaceships]
SELECT * FROM [Colonists]

SELECT * FROM [TravelCards]
SELECT * FROM [Journeys]
SELECT * FROM [SpacePorts]
SELECT * FROM [Planets]


--*************************************************************************************************
-- PROBLEM - 12

CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(200))
AS
	DECLARE @journey INT = (SELECT [Id] FROM [Journeys] WHERE [Id] = @JourneyId)

	IF(@journey IS NULL)
		THROW 50001,'The journey does not exist!',1

	DECLARE @purpose VARCHAR(200) = (SELECT [Purpose] FROM [Journeys] WHERE [Id] = @JourneyId)

	IF(@purpose = @NewPurpose)
		THROW 50001,'You cannot change the purpose!',1

	UPDATE [Journeys] SET [Purpose] = @NewPurpose WHERE [Id] = @JourneyId














