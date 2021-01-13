CREATE DATABASE Movies

USE Movies

CREATE TABLE [Directors](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[DirectorName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
);

CREATE TABLE [Genres](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[GenreName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
);

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[CategoryName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
);

CREATE TABLE [Movies](
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[Title] NVARCHAR(50) NOT NULL,
[DirectorId] INT NOT NULL FOREIGN KEY REFERENCES [Directors](Id),
[CopyrightYear] DATE NOT NULL,
[Length] INT ,
[GenreId] INT NOT NULL FOREIGN KEY REFERENCES [Genres](Id),
[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES [Categories](Id),
[Rating] TINYINT ,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors] 
VALUES
('Scotty Garret', 'Born in Canada'),
('Mark Stoneheart', 'Lives in Wilderness'),
('Holly Saint', 'Lives in Church'),
('Scarlet Stone' , NULL),
('Barry Star' ,NULL)

INSERT INTO [Genres] 
VALUES
('Triller', NULL),
('Comedy', 'This movies are funny'),
('Drama', 'A stories of real life'),
('Horror' , 'These movies are very scary'),
('Documentary' ,NULL)

INSERT INTO [Categories] 
VALUES
('European movies', NULL),
('North American movies', NULL),
('South American movies', NULL),
('Asian movies' , NULL),
('Others' ,NULL);

INSERT INTO [Movies] 
VALUES 
('The true story of Earth', 1, '2011-05-22', 180, 5, 5, 7,NULL),
('Fast and Funny', 3, '2015-05-15', 120, 2, 2, 5,NULL),
('Black Forest', 2, '2019-05-01', 95, 4, 4, 9,NULL),
('The bad guy', 5, '2009-05-03', 125, 3, 3, 7,NULL),
('Silent steps', 4, '2010-05-14', 115, 1, 2, 6,NULL)

SELECT * FROM [Movies]