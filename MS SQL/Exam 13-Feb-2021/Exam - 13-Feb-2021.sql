CREATE DATABASE [Bitbucket]

USE [Bitbucket]


CREATE TABLE [Repositories]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE [Users]
(
[Id] INT PRIMARY KEY IDENTITY,
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
[Email] VARCHAR(30) NOT NULL,
);

CREATE TABLE [Issues]
(
[Id] INT PRIMARY KEY IDENTITY,
[Title] VARCHAR(MAX) NOT NULL,
[IssueStatus] CHAR(6) NOT NULL,
[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories](Id) NOT NULL,
[AssigneeId] INT FOREIGN KEY REFERENCES [Users](Id) NOT NULL
);


CREATE TABLE [RepositoriesContributors]
(
[RepositoryId] INT NOT NULL FOREIGN KEY REFERENCES [Repositories](Id),
[ContributorId] INT NOT NULL FOREIGN KEY REFERENCES [Users](Id),
PRIMARY KEY([RepositoryId],[ContributorId])
);


CREATE TABLE [Commits]
(
[Id] INT PRIMARY KEY IDENTITY,
[Message] VARCHAR(255) NOT NULL,
[IssueId] INT FOREIGN KEY REFERENCES [Issues](Id),
[RepositoryId] INT NOT NULL FOREIGN KEY REFERENCES [Repositories](Id),
[ContributorId] INT NOT NULL FOREIGN KEY REFERENCES [Users](Id)
);


CREATE TABLE [Files]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
[Size] DECIMAL(15,2) NOT NULL,
[ParentId] INT FOREIGN KEY REFERENCES [Files](Id),
[CommitId] INT FOREIGN KEY REFERENCES [Commits](Id) NOT NULL
);


--2 INSERT

INSERT INTO [Files]
VALUES
('Trade.idk',2598.0 , 1, 1),
('menu.net',9238.31 ,2 , 2),
('Administrate.soshy',1246.93 ,3 , 3),
('Controller.php',7353.15, 4,4 ),
('Find.java',9957.86 ,5 ,5 ),
('Controller.json',14034.87 ,3 ,6 ),
('Operate.xix',7662.92 ,7 ,7 )

INSERT INTO [Issues] 
VALUES
('Critical Problem with HomeController.cs file' , 'open' ,1 , 4),
('Typo fix in Judge.html' , 'open' ,4 ,3 ),
('Implement documentation for UsersService.cs' , 'closed' ,8 ,2 ),
('Unreachable code in Index.cs' , 'open' , 9, 8)


--3 UPDATE

UPDATE [Issues] SET [IssueStatus] = 'closed' WHERE AssigneeId = 6

--4 DELETE

DELETE FROM RepositoriesContributors WHERE RepositoryId = 3
DELETE FROM Files WHERE CommitId IN (SELECT [Id] FROM Commits WHERE RepositoryId = 3)
DELETE FROM Commits WHERE RepositoryId = 3
DELETE FROM Issues WHERE RepositoryId = 3


--5 Commits
SELECT Id, Message,RepositoryId, ContributorId FROM Commits
ORDER BY Id, Message, RepositoryId, ContributorId

--6 Front-end

SELECT Id, [Name], Size FROM Files 
WHERE Size  > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC,Id, [Name]

--7 Issue Asigment
SELECT i.Id, CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee FROM Issues AS i
JOIN Users AS u ON  i.AssigneeId = u.Id
ORDER BY i.Id DESC, i.AssigneeId

--8 Single Files

SELECT  Id, [Name], CONCAT(Size,'KB') AS [Size] FROM Files 
WHERE Id NOT IN (SELECT [ParentId] From Files  where ParentId IS NOT NULL
GROUP BY ParentId)  
ORDER BY [Id], [Name],[Size] DESC

--9 Commits in Repositories

SELECT TOP(5) r.[Id],r.[Name], COUNT(c.Id) AS Commits FROM [RepositoriesContributors] AS rc
JOIN [Repositories] AS r ON rc.[RepositoryId] = r.Id
JOIN Commits AS c ON rc.[RepositoryId] = c.[RepositoryId]
GROUP BY r.[Id],r.[Name]
ORDER BY Commits DESC,r.[Id],r.[Name]


--10 Average Size
SELECT u.Username, AVG(f.Size) AS Size FROM Users AS u
JOIN [Commits] AS c ON u.Id = c.ContributorId
JOIN [Files] AS f ON c.Id = f.CommitId
GROUP BY  u.Username
ORDER BY Size DESC, u.Username

--11 All Users Commits

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
	AS
		BEGIN 
		DECLARE @count INT = (SELECT COUNT(*) FROM Commits AS c
						JOIN Users as u ON c.ContributorId = u.Id
						WHERE u.Username = @username)
						
			RETURN @count
		END



--12 Search for Files

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(10))
	AS
		SELECT [Id], [Name], CONCAT([Size],'KB') AS Size FROM Files
		WHERE [Name] LIKE '%.'+ @fileExtension


