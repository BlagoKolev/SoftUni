USE [Gringotts]


--PROBLEM - 1
SELECT COUNT(*) AS [Count] FROM [WizzardDeposits];


--PROBLEM - 2
SELECT MAX([MagicWandSize]) AS [LongestMagicWand] FROM [WizzardDeposits];


--PROBLEM - 3
SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand] FROM [WizzardDeposits]
GROUP BY [DepositGroup];


--PROBLEM - 4
SELECT TOP(2)  [DepositGroup] FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize]) ;


--PROBLEM - 5
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [WizzardDeposits]
GROUP BY [DepositGroup];


--PROBLEM - 6
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [WizzardDeposits]
WHERE [MagicWandCreator]  = 'Ollivander family'
GROUP BY [DepositGroup];


--PROBLEM - 7
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [WizzardDeposits]
WHERE [MagicWandCreator]  = 'Ollivander family'  
GROUP BY [DepositGroup]
HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC;
 


--PROBLEM - 8
SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) FROM [WizzardDeposits]
GROUP BY [DepositGroup],[MagicWandCreator]
ORDER BY [MagicWandCreator],[DepositGroup];



--PROBLEM - 9
SELECT [AgeGroup], SUM([WizardCount]) AS [WizardCount] FROM
	(SELECT 
		CASE 
			WHEN [Age] <= 10 THEN '[0-10]'
			WHEN [Age] > 10 AND [Age] <= 20 THEN '[11-20]'
			WHEN [Age] > 20 AND [Age] <= 30 THEN '[21-30]'
			WHEN [Age] > 30 AND [Age] <= 40 THEN '[31-40]'
			WHEN [Age] > 40 AND [Age] <= 50 THEN '[41-50]'
			WHEN [Age] > 50 AND [Age] <= 60 THEN '[51-60]'
			WHEN [Age] > 60 THEN '[61+]'
			END AS [AgeGroup], COUNT([Age]) AS [WizardCount]
	FROM [WizzardDeposits]
	GROUP BY [Age]) AS [x]
GROUP BY [AgeGroup];



--Second variant of solving PROBLEM - 9
	SELECT [AgeGroup], COUNT(*) AS [WizzardsCount] FROM
(SELECT 
	CASE 
		WHEN [Age] <= 10 THEN '[0-10]'
		WHEN [Age] > 10 AND [Age] <= 20 THEN '[11-20]'
		WHEN [Age] > 20 AND [Age] <= 30 THEN '[21-30]'
		WHEN [Age] > 30 AND [Age] <= 40 THEN '[31-40]'
		WHEN [Age] > 40 AND [Age] <= 50 THEN '[41-50]'
		WHEN [Age] > 50 AND [Age] <= 60 THEN '[51-60]'
		WHEN [Age] > 60 THEN '[61+]'
		END AS [AgeGroup],*
	FROM [WizzardDeposits]
	) AS [AgeGroupQuery]
GROUP BY [AgeGroup];



--Third variant of solving PROBLEM - 9
SELECT [AgeGroup], COUNT(*) AS [WizzardsCount] FROM
	(SELECT 
		CASE 
			WHEN [Age] <= 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 10 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 20 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 30 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 40 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 50 AND 60 THEN '[51-60]'
		ELSE '[61+]'
		END AS [AgeGroup],*
	FROM [WizzardDeposits]
	) AS [AgeGroupQuery]
GROUP BY [AgeGroup];


--Fourth variant of solving PROBLEM - 9
SELECT 
		CASE 
			WHEN [Age] <= 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 10 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 20 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 30 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 40 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 50 AND 60 THEN '[51-60]'
		ELSE '[61+]'
		END AS [AgeGroup], COUNT([Age]) AS [WizzardsCount]
	FROM [WizzardDeposits]
GROUP BY(CASE 
			WHEN [Age] <= 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 10 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 20 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 30 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 40 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 50 AND 60 THEN '[51-60]'
		ELSE '[61+]'
		END);


--PROBLEM - 10
SELECT LEFT([FirstName],1) AS [FirstLetter] FROM [WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY LEFT([FirstName],1)



--PROBLEM - 11
SELECT [DepositGroup], [IsDepositExpired], AVG([DepositInterest]) AS [AverageInterest] FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]


--PROBLEM - 12
SELECT SUM([Diff]) AS [SumDifference] FROM (
SELECT [FirstName] AS [HostWizard], [DepositAmount] AS [HostWizzardDeposit],
	LEAD([FirstName]) OVER(ORDER BY [Id] ASC) AS [GuestWizard],
	LEAD([DepositAmount]) OVER(ORDER BY [Id] ASC) AS [GuestWizardDeposit],
	[DepositAmount] - LEAD([DepositAmount]) OVER(ORDER BY [Id] ASC) AS [Diff]
FROM [WizzardDeposits]
) AS [LeadQuery]
WHERE [GuestWizard] IS NOT NULL












