CREATE DATABASE [Bakery]

USE [Bakery]

CREATE TABLE [Countries]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) UNIQUE
);

CREATE TABLE [Distributors]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) UNIQUE,
[AddressText] NVARCHAR(30),
[Summary] NVARCHAR(200),
[CountryId] INT FOREIGN KEY REFERENCES [Countries]([Id])

);

CREATE TABLE [Ingredients]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30),
[Description] NVARCHAR(200),
[OriginCountryId] INT FOREIGN KEY REFERENCES [Countries]([Id]),
[DistributorId] INT FOREIGN KEY REFERENCES [Distributors]([Id])
);

CREATE TABLE [Customers]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(25),
[LastName] NVARCHAR(25),
[Gender] CHAR(1) CHECK( [Gender] IN ('M','F')),
[Age] INT,
[PhoneNumber] CHAR(10) CHECK(LEN([PhoneNumber]) = 10),
[CountryId] INT FOREIGN KEY REFERENCES [Countries]([Id])
);

CREATE TABLE [Products]
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) UNIQUE,
[Description] NVARCHAR(250),
[Recipe] NVARCHAR(MAX),
[Price] MONEY CHECK([Price] > 0)
);

CREATE TABLE [ProductsIngredients]
(
[ProductId] INT  FOREIGN KEY REFERENCES [Products]([Id]) ,
[IngredientId] INT  FOREIGN KEY REFERENCES [Ingredients]([Id]),
PRIMARY KEY ([ProductId],[IngredientId])
);

CREATE TABLE [Feedbacks]
(
[Id] INT PRIMARY KEY IDENTITY,
[Description] NVARCHAR(255),
[Rate] DECIMAL(10,2) CHECK([Rate] >=0 AND [Rate] <=10),
[ProductId] INT  FOREIGN KEY REFERENCES [Products]([Id]) ,
[CustomerId] INT  FOREIGN KEY REFERENCES [Customers]([Id]) 
);


--*************************************************************************
-- PROBLEM - 2 - INSERT

INSERT INTO [Distributors] 
VALUES
('Deloitte & Touche',2 ,'6 Arch St #9757' ,'Customizable neutral traveling'),
('Congress Title',13 ,'58 Hancock St' ,'Customer loyalty'),
('Kitchen People',1 ,'3 E 31st St #77' ,'Triple-buffered stable delivery'),
('General Color Co Inc',21 ,'6185 Bohn St #72' ,'Focus group'),
('Beck Corporation',23 ,'21 E 64th Ave' ,'Quality-focused 4th generation hardware');


INSERT INTO [Customers] 
VALUES
('Francoise' ,'Rautenstrauch' ,15 ,'M' , '0195698399',5),
('Kendra' ,'Loud' ,22 ,'F' , '0063631526',11),
('Lourdes' ,'Bauswell' , 50,'M' , '0139037043',8),
('Hannah' ,'Edmison' ,18 ,'F' , '0043343686',1),
('Tom' ,'Loeza' ,31 ,'M' , '0144876096',23),
('Queenie' ,'Kramarczyk' ,30 ,'F' , '0064215793',29),
('Hiu' ,'Portaro' ,25 ,'M' , '0068277755',16),
('Josefa' ,'Opitz' ,43 ,'F' , '0197887645',17)

--*************************************************************************
-- PROBLEM - 3 - UPDATE

UPDATE [Ingredients] SET [DistributorId] = 35 WHERE [Name] IN ('Bay Leaf','Paprika','Poppy');
UPDATE [Ingredients] SET [OriginCountryId] = 14 WHERE [OriginCountryId] = 8;

--*************************************************************************
-- PROBLEM - 4 - DELETE

DELETE FROM [Feedbacks] WHERE [CustomerId] = 14 OR [ProductId] = 5

--*************************************************************************
-- PROBLEM - 5 - Products By Price

SELECT [Name], [Price], [Description] FROM [Products]
ORDER BY [Price] DESC, [Name]

--*************************************************************************
-- PROBLEM - 6 - Negative Feedback

SELECT [ProductId], [Rate], [Description], [CustomerId], [Age], [Gender] FROM [Feedbacks] AS f
JOIN [Customers] AS c ON f.CustomerId = c.Id
WHERE [Rate] < 5.0 
ORDER BY [ProductId] DESC, [Rate] 

--*************************************************************************
-- PROBLEM - 7 - Customers without Feedback

SELECT (c.[FirstName] + ' ' + c.[LastName]) AS [CustomerName], c.[PhoneNumber], c.[Gender],f.[Id]  --   , f.Description,f.[Rate]
FROM [Customers] AS c
LEFT JOIN [Feedbacks] as f ON c.Id = f.CustomerId
WHERE f.Id IS NULL 
ORDER BY c.[Id]

SELECT * FROM Feedbacks
SELECT * FROM Ingredients 
SELECT * FROM Distributors 
SELECT * FROM Products
SELECT * FROM Customers
SELECT * FROM Countries
SELECT * FROM ProductsIngredients
--*************************************************************************
-- PROBLEM - 8 - Customers without Feedback

SELECT [FirstName], [Age], [PhoneNumber] FROM [Customers]
WHERE [Age] >= 21 AND ([FirstName] LIKE '%an%' OR [PhoneNumber] LIKE '%38') AND CountryId != 31
ORDER BY [FirstName], [Age] DESC


--*************************************************************************
-- PROBLEM - 9 - Middle Range Distributors

SELECT d.[Name] AS [DistrubutorName], i.[Name] AS [IngredientName], p.[Name] AS [ProductName], AVG(f.[Rate]) AS [AverageRate] 
FROM [ProductsIngredients] AS [pi]
JOIN [Products] AS p ON [pi].ProductId = p.Id
JOIN [Ingredients] AS i ON [pi].IngredientId = i.[Id]
JOIN [Distributors] AS d ON i.DistributorId = d.[Id]
JOIN [Feedbacks] AS f ON p.Id = f.ProductId
--WHERE f.[Rate] >= 5 AND f.[Rate] <= 8
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING  AVG(f.[Rate]) >= 5 AND AVG(f.[Rate]) <= 8
ORDER BY d.[Name], i.[Name], p.[Name]


--*************************************************************************
-- PROBLEM - 10 - Country Representative


SELECT [CountryName],[DistributorName] FROM (
SELECT c.[Name] AS [CountryName], d.[Name] AS [DistributorName], 
DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.[Id]) DESC) AS [rank]
FROM [Countries] AS c
JOIN [Distributors] AS d ON d.CountryId = c.Id
LEFT JOIN [Ingredients] AS i ON d.Id = i.[DistributorId]
GROUP BY c.[Name], d.[Name]) AS x
WHERE [rank] =1
ORDER BY [CountryName],[DistributorName]


--*************************************************************************
-- PROBLEM - 11 - Customers with Countries

CREATE VIEW v_UserWithCountries AS
SELECT ([FirstName] + ' ' + [LastName]) AS [CusotmerName], [Age],[Gender], [Name] AS [CountryName]
FROM Customers AS c
JOIN [Countries] AS coun ON c.CountryId = coun.Id

--*************************************************************************
-- PROBLEM - 12 - Delete Products

CREATE  TRIGGER tr_DeleteProduct ON [Products] INSTEAD OF DELETE
	AS
	BEGIN
		DECLARE @idToDelete INT = (SELECT [Id] FROM deleted)
		DELETE FROM [ProductsIngredients] WHERE [ProductId] =@idToDelete
		DELETE FROM [Feedbacks] WHERE ProductId = @idToDelete
		DELETE FROM Products WHERE Id =@idToDelete
	END


