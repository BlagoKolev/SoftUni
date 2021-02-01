USE [Bank]

--***************************************************************************
--PROBLEM - 9

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
SELECT [FirstName] + ' ' + [LastName] AS [Full Name] FROM [AccountHolders]
END


--***************************************************************************
--PROBLEM - 10

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@amount MONEY)
AS
	BEGIN
	SELECT [FirstName], [LastName] FROM 
	(SELECT ah.[FirstName], ah.[LastName], SUM([Balance]) AS [TotalBalance] FROM [Accounts] AS a
	JOIN [AccountHolders] AS ah ON a.AccountHolderId = ah.Id
	GROUP BY [FirstName], [LastName]
	HAVING SUM([Balance]) > @amount) AS [x]
	ORDER BY [FirstName], [LastName] 
	END

--***************************************************************************
--PROBLEM - 11

CREATE FUNCTION  dbo.ufn_CalculateFutureValue(@deposit DECIMAL(14,4), @interestRate FLOAT, @years INT)
RETURNS MONEY
AS
	BEGIN
		DECLARE @result MONEY
		--SET @interestRate = (@interestRate / 100) + 1
		SET @result = @deposit * POWER(1+@interestRate,@years)
		RETURN @result
	END

	
--***************************************************************************
--PROBLEM - 12

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT,@interestRate FLOAT)
AS
	BEGIN
		SELECT @accountId AS [Account Id],ah.[FirstName], ah.[LastName], a.[Balance] AS [Current Balance], 
		dbo.ufn_CalculateFutureValue(a.[Balance], @interestRate , 5 ) AS [Balance in 5 years] 
		FROM [AccountHolders] AS ah
		JOIN [Accounts] AS a ON ah.[Id] = a.[AccountHolderId]
		WHERE a.[Id] = @accountId
	END




