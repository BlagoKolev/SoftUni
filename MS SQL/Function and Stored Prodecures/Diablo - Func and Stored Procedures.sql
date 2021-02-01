USE [Diablo]

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS TABLE
	AS
	RETURN SELECT (
		SELECT SUM([Cash]) AS [SumCash] FROM 
		(
			SELECT g.[Name],ug.[Cash], 
			ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.[Cash] DESC) AS [RowNumber] 
				FROM [Games] AS g
				JOIN [UsersGames] AS ug ON g.[Id] = ug.[GameId]
				WHERE g.[Name] = @gameName 
		) AS [RowNumQuery]
		WHERE RowNumber % 2 != 0
	) AS [SumCash]
	  
 