USE [SoftUni]

-- PROBLEM 8 - Employees with Three Projects

CREATE PROCEDURE usp_AssignProject(@emloyeeId INT , @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @employee INT = (SELECT [EmployeeID] FROM [Employees] WHERE [EmployeeID] = @emloyeeId)
	DECLARE @project INT = (SELECT [ProjectID] FROM [Projects] WHERE [ProjectID] = @projectID)

	IF (@employee IS NULL OR @project IS NULL)
		BEGIN 
			ROLLBACK
			RAISERROR('Employee or Project does not exist', 16,1)
			RETURN
		END

	DECLARE @countOfProjects INT = (SELECT COUNT(*) FROM EmployeesProjects  WHERE [EmployeeId] = @emloyeeId)

	IF(@countOfProjects >= 3)
		BEGIN
			ROLLBACK
			RAISERROR ('The employee has too many projects!',16,1)
			RETURN
		END
	
	INSERT INTO [EmployeesProjects] 
	VALUES (@emloyeeId,@projectID)

COMMIT

--*****************************************************************************************************
--PROBLEM 9 - Delete Employees

CREATE TABLE [Deleted_Employees](
[EmployeeId] INT PRIMARY KEY NOT NULL ,
[FirstName] VARCHAR(50) NOT NULL,
[LastName] VARCHAR(50) NOT NULL,
[MiddleName] VARCHAR(10) ,
[JobTitle] VARCHAR(50) NOT NULL,
[DepartmentId] INT ,
[Salary] MONEY
)

CREATE TRIGGER tr_DeleteEmployees ON [Employees] FOR DELETE
AS
	INSERT INTO [Deleted_Employees]
	SELECT [FirstName],[LastName],[MiddleName],[JobTitle],[DepartmentId],[Salary] 
	FROM deleted




	
	
