USE SoftUni

-- PROBLEM - 1
SELECT TOP(5) [EmployeeID], [JobTitle],e.[AddressID], [AddressText] FROM [Employees] AS e
JOIN [Addresses] AS a ON   e.[AddressID] = a.[AddressID]
ORDER BY e.[AddressID];


-- PROBLEM - 2
SELECT TOP(50) [FirstName], [LastName], t.[Name] AS [Town],[AddressText] FROM [Employees] AS e
JOIN [Addresses] AS a ON a.[AddressID] = e.[AddressID]
JOIN [Towns] AS t ON t.[TownID] = a.[TownID]
ORDER BY [FirstName],[LastName];


-- PROBLEM - 3
SELECT [EmployeeID], [FirstName], [LastName], d.[Name] AS [DepartmentName] FROM [Employees] AS e
JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
WHERE [Name] LIKE 'Sales'
ORDER BY [EmployeeID] ASC;



-- PROBLEM - 4
SELECT TOP(5) [EmployeeID], [FirstName],[Salary],d.[Name] AS [DepartmentName] FROM [Employees] AS e
JOIN [Departments] AS d ON e.[DepartmentId] = d.[DepartmentID]
WHERE [Salary] > 15000
ORDER BY e.[DepartmentId]



-- PROBLEM - 5
SELECT TOP(3) [EmployeeID],[FirstName] FROM [Employees] AS e
WHERE NOT EXISTS(SELECT [EmployeeID] FROM [EmployeesProjects]
WHERE  e.[EmployeeID] = EmployeesProjects.[EmployeeID])



--PROBLEM - 5 (Another Desicion)
SELECT TOP(3) e.[EmployeeID], [FirstName] FROM [Employees] AS e
LEFT OUTER JOIN [EmployeesProjects] AS ep 
ON ep.[EmployeeID] = e.[EmployeeID]
WHERE ep.[ProjectID] IS NULL
ORDER BY e.[EmployeeID]


-- PROBLEM - 6
SELECT [FirstName], [LastName], [HireDate], d.[Name] AS [DeptName] FROM [Employees] AS e
JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
WHERE [HireDate] > '1999-1-1 00:00:00' AND d.[Name]  IN ('Sales', 'Finance')
ORDER BY [HireDate]


-- PROBLEM - 7
SELECT TOP(5) e.[EmployeeID], [FirstName], p.[Name] AS [ProjectName] FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
WHERE p.[StartDate] > '2002-08-13' AND p.[EndDate] IS NULL
ORDER BY e.[EmployeeID]


-- PROBLEM - 8    
SELECT e.[EmployeeID], [FirstName],
CASE
	WHEN DATEPART(year, p.[StartDate]) >= 2005 THEN NULL
	ELSE p.[Name]
	 END AS [ProjectName] FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
WHERE e.[EmployeeID] = 24


-- PROBLEM - 9
SELECT e1.[EmployeeID], e1.[FirstName], e1.[ManagerID],e2.[FirstName] AS [ManagerName]
FROM [Employees] AS e1
JOIN [Employees] AS e2 ON e1.[ManagerID] = e2.[EmployeeID] 
WHERE e1.[ManagerID] IN (3,7)
ORDER BY e1.[EmployeeID]



-- PROBLEM - 10
SELECT TOP(50) e1.[EmployeeID], e1.[FirstName] + ' ' +e1.[LastName] AS [EmployeeName], 
e2.[FirstName] + ' ' + e2.[LastName] AS [ManagerName], d.[Name] AS [DepartmentName] 
FROM [Employees] AS e1
	JOIN [Employees] AS e2 ON e1.[ManagerID] = e2.[EmployeeID]
	JOIN [Departments] AS d ON d.[DepartmentID] = e1.[DepartmentID]
ORDER BY e1.[EmployeeID]


--PROBLEM  - 11
SELECT d.[DepartmentID], d.[Name], AVG([Salary]) AS [MinAverageSaalry] from [Employees] AS e
JOIN [Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
WHERE e.[DepartmentID] IN (1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16)
GROUP BY d.[Name],d.[DepartmentID]
ORDER BY [MinAverageSaalry]


select * from Departments
select * from Employees

SELECT MIN([AverageSalary]) AS [MinAverageSalary] FROM
(SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary] from [Employees] 
GROUP BY [DepartmentID]) AS [x]



