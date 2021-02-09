CREATE DATABASE [School]

USE [School]

CREATE TABLE [Students]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName]	NVARCHAR(30) NOT NULL,
[MiddleName] NVARCHAR(25),
[LastName] NVARCHAR(30) NOT NULL,
[Age] INT CHECK( [Age] > 0),
[Address] NVARCHAR(50) ,
[Phone] NCHAR(10)
);

CREATE TABLE [Subjects]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name]	NVARCHAR(20) NOT NULL,	
[Lessons]INT NOT NULL
);

CREATE TABLE [Exams]
(
[Id] INT PRIMARY KEY IDENTITY,
[Date] DATETIME2,		
[SubjectId] INT NOT NULL FOREIGN KEY REFERENCES [Subjects]([Id])
);

CREATE TABLE [StudentsExams]
(
[StudentId]	INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL,
[ExamId] INT FOREIGN KEY REFERENCES [Exams]([Id]) NOT NULL,
[Grade] DECIMAL(3,2)
PRIMARY KEY([StudentId], [ExamId])
);

CREATE TABLE [StudentsSubjects]
(
[Id] INT PRIMARY KEY IDENTITY,
[StudentId]	INT FOREIGN KEY REFERENCES [Students]([Id]) NOT NULL,
[SubjectId] INT FOREIGN KEY REFERENCES [Subjects]([Id]) NOT NULL,
[Grade] DECIMAL(3,2)
);

CREATE TABLE [Teachers]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName]	NVARCHAR(20) NOT NULL,	
[LastName] NVARCHAR(20) NOT NULL,	
[Address] NVARCHAR(20) NOT NULL,	
[Phone] CHAR(10) ,
[SubjectId] INT NOT NULL FOREIGN KEY REFERENCES [Subjects]([Id]) 
);

CREATE TABLE [StudentsTeachers]
(
[StudentId]	INT NOT NULL FOREIGN KEY REFERENCES [Students]([Id]),
[TeacherId] INT NOT NULL FOREIGN KEY REFERENCES [Teachers]([Id]),
PRIMARY KEY([StudentId], [TeacherId])
);


--*************************************************************************
--PROBLEM - 2 - INSERT

INSERT INTO [Teachers] 
VALUES
('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4);

INSERT INTO [Subjects]
VALUES
('Geometry',12),
('Health',10),
('Drama',7),
('Sports',9)

--*************************************************************************
--PROBLEM - 3 - Update

UPDATE [StudentsSubjects] SET [Grade] = 6.00 
WHERE [SubjectId]  IN (1,2) AND [Grade] >= 5.50

--*************************************************************************
--PROBLEM - 4 - DELETE
DELETE FROM [StudentsTeachers] 
WHERE TeacherId IN (SELECT [Id] FROM [Teachers] WHERE [Phone] LIKE '%72%')

DELETE FROM [Teachers] WHERE [Phone] LIKE '%72%'

--*************************************************************************
--PROBLEM - 5 - Teen Students

SELECT [FirstName],[LastName],[Age] FROM [Students]
WHERE [Age] >= 12
ORDER BY [FirstName], [LastName]

--*************************************************************************
--PROBLEM - 6 - Students Teachers

SELECT [FirstName], [LastName], COUNT(st.TeacherId) AS [TeachersCount] FROM [StudentsTeachers] AS st
JOIN Students AS s ON st.StudentId = s.Id
GROUP BY [FirstName], [LastName]


--*************************************************************************
--PROBLEM - 7 - Students to Go

SELECT [FullName] FROM (
 SELECT [Id], s.[FirstName] +' ' + s.[LastName] AS [FullName], st.[ExamId] FROM [Students] AS s
 LEFT JOIN [StudentsExams] AS st ON s.[Id] = st.StudentId 
 WHERE st.[ExamId] IS NULL
 ) AS [x]
 ORDER BY [FullName]

 --*************************************************************************
--PROBLEM - 8 - Top Students 

SELECT TOP(10) [FirstName], [LastName], FORMAT(AVG(Grade), 'N2') AS [Grade] FROM [StudentsExams]  AS se
JOIN [Students] AS s ON se.StudentId = s.Id
GROUP BY [FirstName], [LastName]
ORDER BY [Grade] DESC,[FirstName], [LastName]

 --*************************************************************************
--PROBLEM - 9 - Not So In The Studying

SELECT ([FirstName]+ ' ' + ISNULL([MiddleName] +' ', '') +[LastName]) AS [FullName] FROM [StudentsSubjects] AS ss
RIGHT JOIN [Students] AS s ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY [FullName]

 --*************************************************************************
--PROBLEM - 10 - Average Grade per Subject

SELECT  [Name], [AverageGrade] FROM(
SELECT s.[Id], s.[Name], AVG(ss.[Grade]) AS [AverageGrade] FROM [StudentsSubjects] AS ss
JOIN [Subjects] AS s ON ss.SubjectId = s.Id
GROUP BY  s.[Id], s.[Name]) AS [x]
ORDER BY Id 


 --*************************************************************************
--PROBLEM - 11 - Exam Grades

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(100)
AS
	BEGIN 

	DECLARE @student INT = (SELECT [Id] FROM [Students] WHERE [Id] = @studentId )

	IF(@student IS NULL)
	RETURN 'The student with provided id does not exist in the school!'

	IF(@grade > 6.00)
	RETURN CONVERT(VARCHAR(100),'Grade cannot be above 6.00!')


		DECLARE @count INT = (SELECT COUNT([Id]) FROM [StudentsExams] AS se
								JOIN [Students] AS s ON se.StudentId = s.Id
								WHERE (se.[Grade] >= @grade AND se.[Grade] <= @grade +0.5)
								AND s.[Id] = @studentId)
		
		DECLARE @studentName VARCHAR(20) = (SELECT [FirstName] FROM [Students]
													WHERE [Id] = @studentId)

			RETURN 'You have to update ' + CONVERT(VARCHAR(10),@count) + ' grades for the student '+ CONVERT(VARCHAR(10),@studentName)
	END



	 --*************************************************************************
--PROBLEM - 12 - Exclude from school

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
	DECLARE @student VARCHAR(30) = (SELECT [Id] FROM [Students] WHERE [Id] = @StudentId)
	IF(@student IS NULL)
	THROW 50001, 'This school has no student with the provided id!',1

	DELETE FROM [StudentsExams] WHERE StudentId = @StudentId
	DELETE FROM [StudentsTeachers]  WHERE StudentId = @StudentId
	DELETE FROM [StudentsSubjects] WHERE StudentId = @StudentId

	DELETE FROM [Students] WHERE [Id] = @StudentId


