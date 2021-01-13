CREATE DATABASE [SoftUni]

USE [SoftUni]

CREATE TABLE [Towns](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [Addresses](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[AddressText] NVARCHAR(100) NOT NULL,
[TownID] INT NOT NULL FOREIGN KEY REFERENCES [Towns](Id)
)

CREATE TABLE [Departments](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[FirstName] NVARCHAR(20) NOT NULL,
[MiddleName] NVARCHAR(20),
[LastName] NVARCHAR(20) NOT NULL,
[JobTitle] NVARCHAR(50) NOT NULL,
[DepartmentId] INT NOT NULL FOREIGN KEY REFERENCES [Departments](Id),
[HireDate] DATE NOT NULL,
[Salary] DECIMAL NOT NULL,
[AddressId] INT  FOREIGN KEY REFERENCES [Addresses](Id)
);

INSERT INTO [Towns]
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas');

INSERT INTO [Departments]
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance');

INSERT INTO [Employees]([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary])
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4,'2013-02-01',3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1,'2004-03-02',4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5,'2016-08-28',525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2,'2007-12-09',3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3,'2016-08-28',599.88);

SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]


SELECT * FROM [Towns] ORDER BY [Name]
SELECT * FROM [Departments] ORDER BY [Name]
SELECT * FROM [Employees]	ORDER BY [Salary] DESC

SELECT [Name] FROM [Towns] ORDER BY [Name]
SELECT [Name] FROM [Departments] ORDER BY [Name]
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] 	ORDER BY [Salary] DESC

UPDATE  [Employees]
SET [Salary] = [Salary]*1.1

SELECT [Salary] FROM [Employees]
