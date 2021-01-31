USE [SoftUni]

--*****************************************************************
--Problem - 1

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 AS
	SELECT [FirstName], [LastName] FROM [Employees]
	WHERE [Salary] > 35000
GO
	
--*****************************************************************
--Problem - 2

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@limit DECIMAL(18,4))
	AS
	SELECT [FirstName], [LastName] FROM [Employees]
	WHERE [Salary] >= @limit;
  GO

--*****************************************************************
--Problem - 3

CREATE PROCEDURE usp_GetTownsStartingWith(@substring VARCHAR(30))
	AS
	SELECT [Name] AS [Town] FROM Towns
	WHERE [Name] LIKE @substring + '%'
  GO

 --*****************************************************************
--Problem - 4

CREATE PROCEDURE usp_GetEmployeesFromTown(@townName VARCHAR(50))
	AS
	SELECT [FirstName],[LastName] FROM [Employees] AS e
	JOIN [Addresses] AS a ON e.AddressID = a.AddressID
	JOIN [Towns] AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @townName
  GO
	
--*****************************************************************
--Problem - 5

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
	RETURNS VARCHAR(10) 
	AS
	BEGIN
		DECLARE @salaryLevel VARCHAR(10)
		IF 	(@salary < 30000) SET  @salaryLevel = 'Low'
		ELSE IF @salary BETWEEN 30000 AND 50000 SET @salaryLevel = 'Average'
		ELSE IF @salary > 50000 SET @salaryLevel = 'High'
		RETURN @salaryLevel
	END

--*****************************************************************
--Problem - 6

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@levelOfSalary VARCHAR(10))
	AS
	SELECT [FirstName],[LastName] FROM [Employees]
	WHERE dbo.ufn_GetSalaryLevel([Salary]) = @levelOfSalary
  GO

--*****************************************************************
--Problem - 7

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(200), @word VARCHAR(200))
RETURNS BIT
	AS
	BEGIN
		DECLARE @result BIT  
		DECLARE @index TINYINT = 1
		WHILE (@index <= LEN(@word))
			BEGIN
				DECLARE @currentLetter CHAR = SUBSTRING(@word,@index,1)
				IF (@setOfLetters LIKE '%'+ @currentLetter + '%')
				SET @result = 1
				ELSE SET @result = 0 	
			
				SET @index += 1
				IF(@result = 0) BREAK
			END
		RETURN @result 
	END;

--*****************************************************************
--Problem - 8

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
	AS
	BEGIN

	DELETE FROM [EmployeesProjects] 
	WHERE [EmployeeID] IN (SELECT [EmployeeID] FROM [Employees]
	WHERE [DepartmentID] = @departmentId)
	
	UPDATE [Employees]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (SELECT [EmployeeID]   FROM [Employees]
	WHERE [DepartmentID] = @departmentId)

	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT NULL
	
	UPDATE [Departments]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (SELECT [EmployeeID]   FROM [Employees]
	WHERE [DepartmentID] = @departmentId)

	DELETE FROM [Employees] 
	WHERE [DepartmentID] = @departmentId
	
	DELETE FROM [Departments]
	WHERE [DepartmentID] = @departmentId
	
	SELECT COUNT(*) FROM [Employees]
	WHERE [DepartmentID] = @departmentId
	
	END;
	