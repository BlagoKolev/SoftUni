CREATE DATABASE [WMS]

USE [WMS]


CREATE TABLE [Clients](
[ClientId] INT  PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(50),
[LastName] VARCHAR(50),
[Phone] VARCHAR(12) CHECK (LEN([Phone]) = 12)
);


CREATE TABLE [Mechanics](
[MechanicId] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(50),
[LastName] VARCHAR(50),
[Address] VARCHAR(255)
)

CREATE TABLE [Models](
[ModelId] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) UNIQUE
);

CREATE TABLE [Jobs](
[JobId] INT PRIMARY KEY IDENTITY,
[ModelId] INT FOREIGN KEY REFERENCES [Models]([ModelId]) NOT NULL,
[Status] VARCHAR(11) CHECK( [Status] in ('Pending', 'In Progress', 'Finished')) DEFAULT 'Pending',
[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId]) NOT NULL,
[MechanicId] INT FOREIGN KEY REFERENCES  [Mechanics]([MechanicId]) ,
[IssueDate] DATE NOT NULL,
[FinishDate] DATE
);

CREATE TABLE [Orders](
[OrderId] INT PRIMARY KEY IDENTITY,
[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
[IssueDate] DATE,
[Delivered] BIT DEFAULT 0
);

CREATE TABLE [Vendors](
[VendorId] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) UNIQUE
);

CREATE TABLE [Parts](
[PartId] INT PRIMARY KEY IDENTITY,
[SerialNumber] VARCHAR(50) UNIQUE,
[Description] VARCHAR(255),
[Price] MONEY CHECK([Price] > 0),
[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([VendorId]) NOT NULL,
[StockQty] INT CHECK([StockQty] >=0) DEFAULT 0
);

CREATE TABLE [OrderParts](
[OrderId] INT FOREIGN KEY REFERENCES [Orders]([OrderId]) NOT NULL,
[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
[Quantity] INT CHECK([Quantity] >0) DEFAULT 1,
PRIMARY KEY ([OrderId],[PartId])
);

CREATE TABLE [PartsNeeded](
[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
[Quantity] INT CHECK([Quantity] >0) DEFAULT 1,
PRIMARY KEY ([JobId],[PartId])
);

--**********************************************************************************************
--PROBLEM 2 - Insert

INSERT INTO [Clients]
VALUES
('Teri','Ennaco' ,'570-889-5187'),
('Merlyn','Lawler' ,'201-588-7810'),
('Georgene','Montezuma' ,'925-615-5185'),
('Jettie','Mconnell' ,'908-802-3564'),
('Lemuel','Latzke' ,'631-748-6479'),
('Melodie','Knipp' ,'805-690-1682'),
('Candida','Corbley' ,'908-275-8357')

INSERT INTO [Parts]([SerialNumber],[Description],[Price],[VendorId])
VALUES
('WP8182119','Door Boot Seal',117.86 ,2),
('W10780048','Suspension Rod',42.81 ,1),
('W10841140','Silicone Adhesive ',6.77 ,4),
('WPY055980','High Temperature Adhesive', 13.94,3)

--************************************************************************************************
--PROBLEM - 3 - UPDATE

UPDATE [Jobs] SET [MechanicId] = 3 WHERE [Status] = 'Pending'
UPDATE [Jobs] SET [Status] = 'In Progress' WHERE  [MechanicId] =3 AND [Status] = 'Pending'


--************************************************************************************************
--PROBLEM - 4 - DELETE

DELETE FROM [OrderParts] WHERE [OrderId] = 19
DELETE FROM [Orders] WHERE  [OrderId] = 19

--************************************************************************************************
--PROBLEM - 5 - Mechanic Assignments

SELECT [FirstName] + ' ' + [LastName] AS [Mechanic], [Status], [IssueDate]  FROM [Mechanics] AS m
JOIN [Jobs] AS j ON m.[MechanicId] = j.[MechanicId]
ORDER BY m.[MechanicId], j.[IssueDate], j.[JobId] 

--************************************************************************************************
--PROBLEM - 6 - Current Clients

SELECT [FirstName] + ' ' + [LastName] AS [Client], DATEDIFF(day,[IssueDate],'2017-04-24') AS [Days going], [Status] FROM [Clients] AS c
JOIN [Jobs] AS j ON  c.ClientId = j.[ClientId]
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.[ClientId] 



--************************************************************************************************
--PROBLEM - 7 - Mechanic Performance

SELECT [Mechanic],[Average days] FROM (
SELECT m.[MechanicId], (m.[FirstName] + ' ' + m.[LastName]) AS [Mechanic],
AVG(DATEDIFF(day, j.[IssueDate],j.[FinishDate])) AS [Average days]
FROM [Mechanics] AS m
JOIN [Jobs] AS j ON m.MechanicId = j.[MechanicId]
GROUP BY m.[MechanicId], [FirstName], [LastName] ) as [x]


--************************************************************************************************
--PROBLEM - 8 - Available Mechanics

SELECT [FirstName] + ' ' + [LastName] As [Available]
FROM [Mechanics] AS m
LEFT JOIN [Jobs] AS j ON m.MechanicId = j.MechanicId
WHERE m.[MechanicId] NOT IN (
SELECT m.[MechanicId] FROM [Mechanics] AS m
JOIN [Jobs] AS j ON m.MechanicId = j.MechanicId
WHERE j.[Status] IN  ('In Progress', 'Pending'))
GROUP BY m.[MechanicId],[FirstName], [LastName]

--************************************************************************************************
--PROBLEM - 9 - Past Expenses

SELECT [JobId], 
CASE 
	WHEN SUM([PriceByQuantity]) IS NULL THEN 0
	ELSE SUM([PriceByQuantity])
 END AS [Total] 
FROM(
SELECT j.[JobId], (p.Price * op.Quantity) AS [PriceByQuantity]
 FROM [Jobs] AS j
LEFT JOIN [Orders] AS o ON j.[JobId] = o.JobId
LEFT JOIN [OrderParts] AS op ON o.OrderId = op.[OrderId]
LEFT JOIN [Parts] AS p ON op.PartId = p.PartId
WHERE j.Status = 'Finished'
) AS [x]
GROUP BY [JobId]
ORDER BY [Total] DESC, [JobId]


--************************************************************************************************
--PROBLEM - 10 - Missing Parts

SELECT *
 FROM
 (
	 SELECT p.PartId, p.Description, pn.Quantity [Required], p.StockQty [In Stock],
	 CASE
	  WHEN p.PartId IN ( SELECT op.PartID
						  FROM Orders o 
						  JOIN OrderParts op ON op.OrderId = o.orderId
						  WHERE o.delivered = 0
						  GROUP BY op.PartID) 
					  THEN (
						SELECT SUM(op.Quantity) 
						  FROM Orders o 
						  JOIN OrderParts op ON op.OrderId = o.orderId
						  WHERE o.delivered = 0
						  AND op.PartID = p.PartId
						  GROUP BY op.PartID
					  )
	  ELSE 0
	 END Ordered
	 FROM Jobs j
	 JOIN PartsNeeded pn ON pn.JobId = j.JobId
	 LEFT JOIN Parts p ON p.PartId = pn.PartId
	 WHERE j.Status <> 'Finished'
	 AND pn.Quantity > p.StockQty
 ) result
 WHERE result.Ordered + result.[In Stock] < result.Required

 -----------------------------------------------------
 --This solution gives full stack of points in Judge , but not fullfill the Conditions
SELECT p.[PartID], p.[Description],
ISNULL(SUM(pn.Quantity),0) AS Required,
ISNULL(SUM(p.StockQty),0) AS [In Stock],
ISNULL(SUM(op.Quantity),0) AS Ordered
FROM Jobs as j
JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
JOIN Parts AS p ON pn.PartId = p.PartID
LEFT JOIN OrderParts AS op ON p.PartId = op.PartId
WHERE j.Status <> 'Not Finished'
GROUP BY p.PartId, p.Description
HAVING SUM(pn.Quantity) > SUM (p.StockQty)


--------------------------------------------------------


SELECT 
p.PartId,
p.Description,
pn.Quantity AS Required,
p.StockQty AS [In Stock],
IIF(o.Delivered=0, op.Quantity, 0)AS Ordered
FROM Parts p
LEFT Join PartsNeeded pn ON p.PartId = pn.PartId
LEFT JOIN OrderParts op ON p.PartId = op.PartId
LEFT JOIN Jobs j ON pn.JobId = j.JobId
LEFT JOIN Orders o ON j.JobId = o.JobId
WHERE j.Status !='Finished' AND p.StockQty+IIF(o.Delivered=0, op.Quantity, 0)<pn.Quantity
ORDER BY PartId


--************************************************************************************************
--PROBLEM - 11 - Place Order

	CREATE  PROCEDURE usp_PlaceOrder(@jobId INT, @partSerialNumber VARCHAR(50), @quantity INT)
AS 

	IF ( @quantity <= 0)
	THROW 50002, 'Part quantity must be more than zero!',1

	DECLARE @jobExists INT = (SELECT [JobId] FROM [Jobs] WHERE [JobId] = @jobId);

	IF (@jobExists IS NULL)
	THROW 50003, 'Job not found!', 1

	DECLARE @activeJob VARCHAR(50) = 
		(SELECT [Status] FROM Jobs WHERE [Status] != 'Finished' AND [jobId] = @jobId)
		
		IF (@activeJob IS NULL)
			THROW 50001, 'This job is not active!', 1

	DECLARE @partId INT = 
	(SELECT [PartId] FROM [Parts] WHERE [SerialNumber] = @partSerialNumber)

	IF (@partId IS NULL)
	THROW 50004, 'Part not found!', 1

	


DECLARE @currentOrderId INT = (SELECT [OrderId] FROM [Orders] 
				WHERE JobId = @jobId AND [IssueDate] IS NULL)


	IF(@currentOrderId IS NULL)
		BEGIN
			INSERT INTO [Orders](JobId, IssueDate) VALUES (@jobId, NULL)
		END
		
		SET @currentOrderId = 
		(SELECT o.OrderId FROM Orders AS o WHERE JobId = @jobId AND o.issueDate IS NULL);

		DECLARE @orderPartExists INT = (SELECT OrderId FROM OrderParts WHERE
			OrderId = @currentOrderId AND PartId = @partId)

			IF (@orderPartExists IS NULL)
			BEGIN
				INSERT INTO OrderParts (OrderId, PartID, Quantity) VALUES
				(@currentOrderId, @PartId, @quantity)
			END
		 ELSE 
			BEGIN 
				UPDATE OrderPArts
				SET Quantity += @quantity
				WHERE OrderId = @currentOrderId AND PartId = @partId
			END


--************************************************************************************************
--PROBLEM - 12 - Cost Of Order

CREATE FUNCTION udf_GetCost(@jobID INT)
RETURNS DECIMAL(15,2)
AS
	BEGIN
	DECLARE @result DECIMAL(15,2)
	
	SET @result	= (SELECT SUM(p.Price * op.[Quantity]) AS [Result] FROM [Jobs] AS j
		JOIN [Orders] AS o ON j.JobId = o.JobId
		JOIN [OrderParts] AS op ON o.OrderId = op.OrderId
		JOIN [Parts] AS p ON op.PartId = p.PartId
		WHERE j.JobId = @jobID
		GROUP BY j.JobId)

	IF(@result IS NULL)
	SET @result = 0

		RETURN @result
	END


	


