USE [Diablo]
--********************************************************************************
--PROBLEM - Triggers

CREATE OR ALTER TRIGGER tr_RestrictItems ON [UserGameItems] INSTEAD OF INSERT
AS
	DECLARE @itemID INT = (SELECT [ItemId] FROM inserted)
	DECLARE @userGameId INT = (SELECT [UserGameId] FROM inserted)

	DECLARE @itemLevel INT = (SELECT [MinLevel] FROM [Items] WHERE [Items].[Id] = @itemID)
	DECLARE @userGameLevel INT = (SELECT [Level] FROM [UsersGames] WHERE [Id] = @userGameId)

	IF (@userGameLevel >= @itemLevel)
		BEGIN
			INSERT INTO [UserGameItems] 
			VALUES (@itemID ,@userGameId)
		END
	

--***********************************************************************************************
-- Add 50000 to specific users acounts

CREATE OR ALTER PROCEDURE usp_AddBonusCash 
AS
	UPDATE [UsersGames] SET [Cash]  += 50000 
	WHERE  [GameId] = (SELECT [Id]  FROM [Games] WHERE [Name] = 'Bali')
		AND
		[UserId] IN (SELECT [Id] FROM [Users] 
		WHERE [Username]  IN ( 'baleremuda',' loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))
	
	exec _AddBonusCash 
--***********************************************************************************************
--Buy specific items for ABOVE Users for "Bali' game  


CREATE OR ALTER PROCEDURE usp_buyItemsForBali (@userID INT, @itemId INT)
AS	
	DECLARE @user INT = (SELECT [Id] FROM [Users] WHERE Id = @userID)
	DECLARE @item INT = (SELECT [Id] FROM [Items] WHERE Id = @itemId)
	BEGIN TRANSACTION
		IF (@user IS NULL OR @item IS NULL)
			BEGIN
				ROLLBACK
				RAISERROR('User or Item does nt exist', 16,1)
				RETURN
			END

		DECLARE @userCash DECIMAL(15,2) = (SELECT [Cash] FROM [UsersGames] 
		WHERE [userId] = @userId AND [GameId] = 212)

		DECLARE @itemPrice DECIMAL(15,2) = (SELECT [Price] FROM [Items] WHERE [Id] = @itemId)

		IF (@userCash - @itemPrice < 0)
			BEGIN
				ROLLBACK
				RAISERROR('Insufficient funds!', 16,1)
				RETURN
			END

			UPDATE [UsersGames] SET [Cash] -= @itemPrice
			WHERE UserID = @userId AND [GameId] = 212

			INSERT INTO [UserGameItems]
			VALUES (@itemId,212)
	COMMIT


	--Check selected users
	SELECT * FROM Users WHERE Username IN 
	('baleremuda',' loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')


	--Buy first group ot Items for all users 
	DECLARE @startItemId INT = 251

	WHILE(@startItemId <= 299)
		BEGIN
			EXEC usp_buyItemsForBali 22, @startItemId
			EXEC usp_buyItemsForBali 37, @startItemId
			EXEC usp_buyItemsForBali 52, @startItemId
			EXEC usp_buyItemsForBali 61, @startItemId

			SET @startItemId +=1
		END



	--Buy second group ot Items for all users 
	DECLARE @secondGroupStartItemID INT = 501

		WHILE(@secondGroupStartItemID <= 599)
		BEGIN
			EXEC usp_buyItemsForBali 22, @secondGroupStartItemID
			EXEC usp_buyItemsForBali 37, @secondGroupStartItemID
			EXEC usp_buyItemsForBali 52, @secondGroupStartItemID
			EXEC usp_buyItemsForBali 61, @secondGroupStartItemID

			SET @secondGroupStartItemID +=1
		END
--********************************************************************************************
--Select all users in the current game ("Bali") with their items.
--Display username, game name, cash and item name. 
--Sort the result by username alphabetically, then by item name alphabetically.

	SELECT u.[Username], g.[Name], ug.[Cash],i.[Name] AS [Item Name] FROM [Users] AS u
	JOIN [UsersGames] AS ug ON u.[Id] = ug.[UserId]
	JOIN [Games] AS g ON ug.[GameId] = g.[Id]
	JOIN [UserGameItems] AS ugi ON ug.[GameId] = ugi.[UserGameId]
	JOIN [Items] AS i ON ugi.[ItemId] = i .Id
	WHERE ug.[GameId] = 212
	ORDER BY u.[Username],g.[Name]


--********************************************************************************************
--PROBLEM - 7 *Massive Shopping    StamatId = 9

CREATE PROCEDURE usp_BuyItems (@userId INT, @gameId INT)
AS
	DECLARE @user INT = (SELECT [Id] FROM [Users] WHERE [Id] = @userId)
	DECLARE @game INT = (SELECT [Id] FROM [Games] WHERE [Id] = @gameId)

	IF (@user IS NULL)
		THROW 90000,'Invalid USER',1;
	
	IF (@game IS NULL)
		THROW 90000,'Invalid GAME',1;
	
	DECLARE @firstGroupStart INT = 11;
	DECLARE @secondGroupStart INT =19;

	BEGIN TRANSACTION
		DECLARE @countOfItemsFirstGroup INT = (SELECT COUNT(*) FROM [Items] WHERE [MinLevel] IN (11,12))

		WHILE(@countOfItemsFirstGroup  >0)
		DECLARE @itemPrice = (SELECT [Price] FROM [Items]
			UPDATE [UsersGames] SET [Cash] -= 

			@countOfItemsFirstGroup -= 1;
	COMMIT






SELECT * FROM [Games] WHERE [Name] = 'Safflower'
SELECT * FROM [Items] WHERE [MinLevel] IN (11,12)
SELECT * FROM [UserGameItems] WHERE [UserGameId] = 87
SELECT * FROM [UserGameItems] WHERE [ItemId] IN (65,140,357,388,390,400) AND [UserGameId] = 87
SELECT * FROM [Users] WHERE [Username] = 'Stamat'
SELECT * FROM [UsersGames] WHERE UserId = 9 AND [GameId] = 87

SELECT COUNT(*) FROM [Items] WHERE [MinLevel] IN (11,12)

DECLARE @sum DECIMAL = 0
WHILE (@@ROWCOUNT <= 14)
BEGIN
 SET @sum += (SELECT [Price] FROM [Items] WHERE [MinLevel] IN (11,12))
 @@ROWCOUNT +=1
 END