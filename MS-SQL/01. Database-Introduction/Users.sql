CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL,
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
	VALUES
		('Peter0', '123456', '05.19.2020', 0),
		('Peter1', '423143', '06.19.2020', 1),
		('Peter2', '4576868', '07.19.2020', 0),
		('Peter3', 'WEFEFEQW', '08.19.2020', 1),
		('Peter4', 'DQ4R4RFQ', '09.19.2020', 0)

SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC071AA53EE3]

ALTER TABLE Users
ADD CONSTRAINT PK_User_CompositeIdUsername
PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK (LEN([Password]) >= 5)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
	VALUES
		('Peter10', '123', '05.19.2020', 0)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
	VALUES
		('Peter10', '123gkfrg', '05.19.2020', 0)

SELECT * FROM Users

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username, [Password], IsDeleted)
	VALUES
		('PeterNoTime', '123gkfrg', 0)

SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT [PK_User_CompositeIdUsername]

ALTER TABLE Users
ADD CONSTRAINT PK_User_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)

