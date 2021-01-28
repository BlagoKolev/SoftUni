USE [SoftUni]

--PROBLEM - 13
SELECT [DepartmentID], SUM([Salary]) AS [TotalSalary] FROM [Employees]
GROUP BY [DepartmentID]


--PROBLEM - 14
SELECT [DepartmentID], MIN([Salary]) AS [MinimumSalary] FROM [Employees]
WHERE [DepartmentID] IN (2,5,7) AND [HireDate] > '01/01/2000'
GROUP BY [DepartmentID]


--PROBLEM - 15
SELECT *
INTO [EditEmployees]
FROM [Employees]
WHERE [Salary] > 30000

DELETE FROM [EditEmployees]
WHERE [ManagerID] = 42

UPDATE [EditEmployees]
SET [Salary] = [Salary] + 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID], AVG(Salary) AS [AverageSalary] FROM [EditEmployees]
GROUP BY [DepartmentID]



--PROBLEM - 16
SELECT [DepartmentID], MAX([Salary]) AS [MaxSalary] FROM [Employees]
GROUP BY [DepartmentID]
HAVING  MAX([Salary]) NOT BETWEEN 30000  AND 70000


--PROBLEM - 17
SELECT COUNT(*)  AS [Count] FROM [Employees]
WHERE [ManagerID] IS NULL


--PROBLEM - 18
SELECT [DepartmentID], [Salary] AS [ThirdHighestSalary] FROM (
SELECT [DepartmentID], [Salary],
DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [SalaryRank]
FROM [Employees]
GROUP BY [DepartmentID], [Salary]
) AS [SalaryRankingQuery]
WHERE [SalaryRank] = 3
--ORDER BY [DepartmentID]


--PROBLEM - 19
SELECT TOP(10) e1.[FirstName], e1.[LastName], e1.[DepartmentID] FROM [Employees] AS e1
WHERE e1.Salary > (SELECT  AVG([Salary]) AS [AverageSalary] FROM [Employees] AS e2
					WHERE e2.DepartmentID = e1.DepartmentID
					GROUP BY [DepartmentID])



