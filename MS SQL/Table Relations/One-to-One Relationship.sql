CREATE DATABASE TableRelations

USE TableRelations

CREATE TABLE Persons(
[Id]  INT PRIMARY KEY NOT NULL IDENTITY,
[FirstName] NVARCHAR(30) NOT NULL,
[Salary] DECIMAL(7,2) NOT NULL,
[PassportID] INT NOT NULL
);

CREATE TABLE Passports(
[PassportID] INT NOT NULL,
[PassportNumber] NVARCHAR(8) NOT NULL
);

ALTER TABLE [Passports]
ADD CONSTRAINT PK_PassportID PRIMARY KEY([PassportID]);

ALTER TABLE [Persons]
ADD CONSTRAINT FK_IdPassportID FOREIGN KEY ([PassportID]) REFERENCES [Passports]([PassportID]);


INSERT INTO [Passports]
VALUES
(101, 'N34FG21B'),
(102,'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO [Persons]
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)








