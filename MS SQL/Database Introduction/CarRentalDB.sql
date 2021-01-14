CREATE DATABASE CarRental

USE CarRental

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[CategoryName] NVARCHAR(30) NOT NULL,
[DailyRate] INT NOT NULL,
[WeeklyRate] INT NOT NULL,
[MonthlyRate] INT NOT NULL,
[WeekendRate] INT NOT NULL
);


CREATE TABLE [Cars](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[PlateNumber] NVARCHAR(8) NOT NULL CHECK(LEN([PlateNumber]) = 8),
[Manufacturer] NVARCHAR(30) NOT NULL,
[Model] NVARCHAR(30) NOT NULL,
[CarYear] DATE NOT NULL,
[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES [Categories](Id),
[Doors] TINYINT ,
[Picture] VARBINARY(MAX) CHECK(DATALENGTH([Picture]) <= 4000*1024),
[Condition] NVARCHAR(100),
[Available] BIT NOT NULL
);


CREATE TABLE [Employees](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[FirstName] NVARCHAR(20) NOT NULL,
[LastName] NVARCHAR(20) NOT NULL,
[Title] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX),
);

CREATE TABLE [Customers](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[DriverLicenceNumber] NVARCHAR(10) NOT NULL CHECK(LEN([DriverLicenceNumber]) = 10),
[FullName] NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(200) NOT NULL,
[City] NVARCHAR(50) NOT NULL,
[ZipCode] INT ,
[Notes] NVARCHAR(MAX)
);


CREATE TABLE [RentalOrders](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[EmployeeId] INT NOT NULL FOREIGN KEY REFERENCES [Employees](Id),
[CustomerId] INT NOT NULL FOREIGN KEY REFERENCES [Customers](Id),
[CarId] INT NOT NULL FOREIGN KEY REFERENCES [Cars](Id),
[TankLevel] TINYINT NOT NULL,
[KilometrageStart] INT NOT NULL,
[KilometrageEnd] INT NOT NULL,
[TotalKilometrage] INT NOT NULL,
[StartDate] DATETIME2 NOT NULL,
[EndDate] DATETIME2 NOT NULL,
[TotalDays] TINYINT NOT NULL,
[RateApplied] BIT,
[TaxRate] DECIMAL(7,2),
[OrderStatus] NVARCHAR(100),
[Notes] NVARCHAR(MAX)
);


INSERT INTO [Categories]
VALUES
('Motocycle',20, 100,400,50),
('Light Vehicle', 50, 200, 1300, 120),
('Cargo', 100, 400, 2000, 200)  

INSERT INTO [Cars]([PlateNumber],[Manufacturer],[Model],[CarYear],[CategoryId],[Doors],[Available] )
VALUES
('CT8011AM', 'BMW', 'E90', '2005-05-21', 2, 5, 1),
('CT8561AP', 'FORD', 'Transit', '2000-12-08', 3, 5, 1),
('CT5561CP', 'HONDA', 'BRC','2005-01-21', 1, NULL, 1)

INSERT INTO [Employees]([FirstName], [LastName], [Title])
VALUES
('John', 'Smith' , 'Manager'),
('Derek', 'Coronel', 'Worker'),
('Andrey', 'Smirnoff' ,'Worker')

INSERT INTO [Customers]([DriverLicenceNumber],[FullName],[Address],[City])
VALUES
('US12345600', 'Barry Jones', 'Lancey Lane 123', 'Lounsville'),
('US12300200', 'Harry Kane', 'Strawbery Boulevard 23', 'Lounsville'),
('US12302000', 'Joseph Morrata', 'Apple Avenue 77', 'Lounsville')


INSERT INTO [RentalOrders]([EmployeeId],[CustomerId],[CarId],[TankLevel],[KilometrageStart],[KilometrageEnd],[TotalKilometrage],[StartDate],[EndDate],[TotalDays])
VALUES 
(3,1,2,50,100000,101000,101000,'2020-05-05','2020-05-08',4),
(2,2,2,50,200000,201000,201000,'2020-05-05','2020-05-07',3),
(3,3,2,50,150000,152000,152000,'2021-01-01','2021-01-13',14)


SELECT * FROM [Categories]
SELECT * FROM [Cars]
SELECT * FROM [Employees]
SELECT * FROM [Customers]
SELECT * FROM [RentalOrders]
