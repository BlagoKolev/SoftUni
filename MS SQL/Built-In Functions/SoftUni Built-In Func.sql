SELECT [FirstName], [LastName] FROM [Employees]
WHERE [FirstName] LIKE 'sa%';


SELECT [FirstName], [LastName] FROM [Employees]
WHERE [LastName] LIKE '%ei%';


SELECT [FirstName] FROM [Employees]
WHERE [DepartmentID] IN(3,10) AND (YEAR([HireDate]) >= 1995 AND Year([HireDate])<= 2005) ;


SELECT [FirstName], [LastName] FROM [Employees]
WHERE [JobTitle] NOT LIKE '%engineer%';


SELECT [Name] FROM [Towns]
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name];


SELECT * FROM [Towns]
WHERE [Name] LIKE ('m%') OR [Name] LIKE ('k%') OR [Name] LIKE ('b%') OR [Name] LIKE ('e%') 
ORDER BY [Name];


SELECT * FROM [Towns]
WHERE [Name] NOT LIKE 'r%' AND [Name] NOT LIKE 'b%' AND [Name] NOT LIKE 'd%' 
ORDER BY [Name];


CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName],[LastName] FROM [Employees]
WHERE YEAR([HireDate]) > 2000;


SELECT [FirstName],[LastName] FROM [Employees]
WHERE LEN([LastName]) = 5


SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
DENSE_RANK () OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM [Employees]
	WHERE [Salary] >= 10000 AND [Salary] <= 50000
	ORDER BY [Salary] DESC;

SELECT * FROM(
	SELECT [EmployeeID], [FirstName], [LastName], [Salary],	
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM [Employees]
	WHERE ([Salary] >= 10000 AND [Salary] <= 50000) 
	) AS [t]
	WHERE t.[Rank] =2
	ORDER BY [Salary] DESC;








