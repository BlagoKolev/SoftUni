USE Bank

--***********************************************************************
--PROBLEM - 1

CREATE TABLE [Logs] (
[LogId] INT PRIMARY KEY NOT NULL IDENTITY,
[AccountId] INT NOT NULL,
[OldSum] DECIMAL ,
[NewSum] DECIMAL
);

CREATE TRIGGER tr_AccountsEntryLog ON [Accounts] FOR UPDATE
AS
	DECLARE @newSum DECIMAL(14,2) = (SELECT [Balance] FROM inserted)
	DECLARE @oldSum DECIMAL(14,2) = (SELECT [Balance] FROM deleted)
	DECLARE @accountId INT  = (SELECT [Id] From inserted)

	INSERT INTO [Logs]([AccountId],[OldSum], [NewSum] )
	VALUES (@accountId, @oldSum, @newSum)
	

--***********************************************************************
--PROBLEM - 2

CREATE TABLE NotificationEmails
(Id INT PRIMARY KEY NOT NULL IDENTITY, 
Recipient INT FOREIGN KEY REFERENCES Accounts([Id]) NOT NULL, 
[Subject] VARCHAR(200), 
Body VARCHAR(MAX)
)

CREATE TRIGGER tr_LogsEmails ON [Logs] FOR INSERT
AS 
	DECLARE @accountId INT = (SELECT TOP(1)[AccountId] FROM inserted)
	DECLARE @oldSum DECIMAL(14,2) = (SELECT TOP(1) [OldSum] FROM inserted)
	DECLARE @newsum DECIMAL(14,2) = (SELECT TOP(1) [NewSum] FROM inserted)

	INSERT INTO [NotificationEmails] (Recipient, [Subject], [Body])
	VALUES (@accountId, 
	'Balance change for account: ' + CAST(@accountId AS VARCHAR(20)),
	' On ' + CONVERT(VARCHAR(30),GETDATE(),103) + ' your balance was changed from ' + CAST(@oldSum AS VARCHAR(20)) +' to ' + CAST(@newsum AS VARCHAR(20)))


--***********************************************************************
--PROBLEM - 3

CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(14,4))
AS
	IF(@MoneyAmount > 0)
		BEGIN
			UPDATE [Accounts] 
			SET [Balance] += @MoneyAmount
			WHERE [Accounts].[Id] = @AccountId
		END


--***********************************************************************
--PROBLEM - 4

CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(14,4))
AS
	DECLARE @account INT = (SELECT [Id] FROM [Accounts] WHERE  [Id] = @AccountId)

	IF (@account IS NULL)
		THROW 50001, 'No such account',1

	IF (@MoneyAmount > 0 )
		BEGIN
			UPDATE [Accounts] 
			SET [Balance] -= @MoneyAmount
			WHERE [Id] = @AccountId
		END

--***********************************************************************
--PROBLEM - 5		

CREATE PROCEDURE usp_TransferMoney(@SenderId INT , @ReceiverId INT, @Amount DECIMAL(14,4))
AS
			BEGIN TRANSACTION
				EXEC usp_WithdrawMoney @SenderId, @Amount
				EXEC usp_DepositMoney @ReceiverId, @Amount
			COMMIT


		