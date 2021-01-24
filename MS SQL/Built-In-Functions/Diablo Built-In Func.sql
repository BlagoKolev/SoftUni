SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
WHERE YEAR([Start]) IN (2011,2012)
ORDER BY [Start],[Name];


SELECT [UserName], 
SUBSTRING([Email],CHARINDEX('@',[Email])+1,LEN([Email]) - CHARINDEX([Email],'@')) AS 'Email Provider'
FROM [Users]
ORDER BY [Email Provider],[UserName]


SELECT [UserName],[IPAddress] FROM [Users]
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [UserName]


SELECT [Name] AS  [Game],
CASE
	WHEN DATEPART(HOUR,[Start]) >=0 AND DATEPART(HOUR,[Start]) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR,[Start]) >=12 AND DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon'
	WHEN DATEPART(HOUR,[Start]) >=18 AND DATEPART(HOUR,[Start]) < 24 THEN 'Evening'
	END AS [Part Of The Day],
CASE
	WHEN [Duration] <=3 THEN 'Extra Short'
	WHEN [Duration]>=4 AND [Duration] <=6 THEN 'Short'
	WHEN [Duration] > 6 THEN 'Long'
	ELSE  'Extra Long'
	END AS [Duration]
FROM [GAMES]
ORDER BY [Game], [Duration], [Part Of The Day]





