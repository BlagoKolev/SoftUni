CREATE DATABASE [University]

USE [University]

CREATE TABLE [Subjects](
[SubjectID] INT PRIMARY KEY NOT NULL IDENTITY,
[SubjectName] VARCHAR(50) NOT NULL
);

CREATE TABLE [Majors](
[MajorID] INT PRIMARY KEY NOT NULL IDENTITY,
[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE [Students](
[StudentID] INT PRIMARY KEY NOT NULL IDENTITY,
[StudentNumber] INT NOT NULL,
[StudentName] VARCHAR(50),
[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
);

CREATE TABLE [Agenda](
[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
PRIMARY KEY ([StudentID],[SubjectID])
);

CREATE TABLE [Payments](
[PaymentID] INT PRIMARY KEY NOT NULL IDENTITY,
[PaymentDate] DATE,
[PaymentAmount] DECIMAL(7,2),
[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
);

