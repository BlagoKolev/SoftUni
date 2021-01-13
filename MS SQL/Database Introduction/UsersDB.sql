USE Minions

CREATE TABLE [Users](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX) CHECK(DATALENGTH([ProfilePicture]) <= 900 *1024),
[LastLoginTime] DATETIME2,
[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] 
VALUES
('User1', '123456', NULL, NULL,0),
('User2', '123456', NULL, NULL,1),
('User3', '123456', NULL, NULL,0),
('User4', '123456', NULL, NULL,0),
('User5', '123456', NULL, NULL,0)


ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC0746C8A931]

ALTER TABLE [Users]
ADD CONSTRAINT PK_IdUsername PRIMARY KEY([Id],[Username]);

ALTER TABLE [Users]
ADD CONSTRAINT CHK_PasswordLenght CHECK(LEN(Password) >= 6);

INSERT INTO [Users]([Username], [Password], [IsDeleted])
VALUES('John', '123456', 0)

SELECT * FROM [Users]
DELETE FROM [Users] WHERE [Username] = 'John'
SELECT * FROM [Users]

ALTER TABLE [Users]
	ADD CONSTRAINT DF_LastLogin DEFAULT GETDATE() FOR [LastLoginTime] ;

	ALTER TABLE [Users]
	DROP CONSTRAINT [PK_IdUsername]

	ALTER TABLE [Users]
	ADD CONSTRAINT PK_Id PRIMARY KEY([Id]);

	ALTER TABLE [Users]
	ADD CONSTRAINT UC_Username UNIQUE([Username])

	ALTER TABLE [Users]
	ADD CONSTRAINT CHK_Username CHECK(LEN([Username]) >= 3)

	

