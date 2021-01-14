CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[FirstName] NVARCHAR(20) NOT NULL,
[LastName] NVARCHAR(20) NOT NULL,
[Title] NVARCHAR(30) NOT NULL,
[Notes] NVARCHAR(500)
);


CREATE TABLE [Customers](
[AccountNumber] INT PRIMARY KEY NOT NULL IDENTITY,
[FirstName] NVARCHAR(20) NOT NULL,
[LastName] NVARCHAR(20) NOT NULL,
[PhoneNumber] INT NOT NULL CHECK(LEN([PhoneNumber]) = 10),
[EmergencyName] NVARCHAR(50),
[EmergencyNumber] INT CHECK(LEN([EmergencyNumber]) = 10),
[Notes] NVARCHAR(500)
);


CREATE TABLE [RoomStatus](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[RoomStatus] NVARCHAR(11) NOT NULL CHECK([RoomStatus] LIKE 'Unavailable' OR [RoomStatus] LIKE 'Available' OR [RoomStatus] LIKE 'Reserved'),
[Notes] NVARCHAR(500)
);


CREATE TABLE [RoomTypes](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[RoomType] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(500)
);


CREATE TABLE [BedTypes](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[BedType] NVARCHAR(20) NOT NULL,
[Notes] NVARCHAR(500)
);


CREATE TABLE [Rooms](
[RoomNumber] INT PRIMARY KEY NOT NULL IDENTITY,
[RoomType] INT NOT NULL FOREIGN KEY REFERENCES [RoomTypes](Id),
[BedType] INT NOT NULL FOREIGN KEY REFERENCES [BedTypes](Id),
[Rate] TINYINT ,
[RoomStatus] INT NOT NULL FOREIGN KEY REFERENCES [RoomStatus](Id),
[Notes] NVARCHAR(500)
);

CREATE TABLE [Payments](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[EmployeeId] INT NOT NULL FOREIGN KEY REFERENCES [Employees](Id),
[PaymentDate] DATE NOT NULL,
[AcountNumber] INT NOT NULL FOREIGN KEY REFERENCES [Customers](AccountNumber),
[FirstDateOccupied] DATE NOT NULL,
[LastDateOccupied] DATE NOT NULL,
[TotalDays] TINYINT NOT NULL,
[AmountCharged] DECIMAL NOT NULL,
[TaxRate] DECIMAL NOT NULL,
[TaxAmount] DECIMAL	 NOT NULL,
[PaymentTotal] DECIMAL NOT NULL,
[Notes] NVARCHAR(500)
);


CREATE TABLE [Occupancies](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[EmployeeId] INT NOT NULL FOREIGN KEY REFERENCES [Employees](Id) ,
[DateOccupied] DATE NOT NULL ,
[AccountNumber] INT NOT NULL FOREIGN KEY REFERENCES [Customers](AccountNumber),
[RoomNumber] INT NOT NULL FOREIGN KEY REFERENCES [Rooms](RoomNumber),
[RateApplied] TINYINT,
[PhoneCharge] BIT,
[Notes] NVARCHAR(500)
);



INSERT INTO [Employees]([FirstName],[LastName],[Title])
VALUES
('John', 'Smith', 'Receptionist'),
('Ramon', 'Gonsales', 'Receptionist'),
('Horhe', 'Agguero', 'Driver')

INSERT INTO[Customers]([FirstName],[LastName],[PhoneNumber])
VALUES
('Rory', 'Jones', 1962323151),
('Chloe', 'Cares', 1796236515),
('Mony', 'Bonbony', 1866632315)

INSERT INTO [RoomStatus]([RoomStatus])
VALUES
('Unavailable'),
('Available'),
('Reserved')

INSERT INTO [RoomTypes]([RoomType])
VALUES
('Apartment'),
('Single Room'),
('Double Room')

INSERT INTO [BedTypes]([BedType])
VALUES
('Bedroom'),
('Separated beds'),
('Bedroom and beds')

INSERT INTO [Rooms]([RoomType],[BedType],[RoomStatus])
VALUES
(1,1,1),
(2,2,2),
(1,3,3)

INSERT INTO [Payments]([EmployeeId],[PaymentDate],[AcountNumber],[FirstDateOccupied],
[LastDateOccupied],[TotalDays],[AmountCharged],[TaxRate],[TaxAmount],[PaymentTotal])
VALUES
(1,'2021-05-25',1,'2021-05-15','2021-05-25', 11,1000, 0.2, 200, 1200),
(1,'2021-05-25',1,'2021-05-15','2021-05-25', 11,1000, 0.2, 200, 1200),
(1,'2021-05-25',1,'2021-05-15','2021-05-25', 11,1000, 0.2, 200, 1200)

INSERT INTO [Occupancies]([EmployeeId],[DateOccupied],[AccountNumber],[RoomNumber])
VALUES
(1,'2021-05-30',2,1),
(2,'2021-06-13',2,2),
(2,'2021-05-14',2,3)

SELECT * FROM [Employees]
SELECT * FROM [Customers]
SELECT * FROM [RoomStatus]
SELECT * FROM [RoomTypes]
SELECT * FROM [Rooms]
SELECT * FROM [Payments]
SELECT * FROM [Occupancies]