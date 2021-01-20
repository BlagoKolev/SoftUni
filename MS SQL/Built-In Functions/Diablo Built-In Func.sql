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




