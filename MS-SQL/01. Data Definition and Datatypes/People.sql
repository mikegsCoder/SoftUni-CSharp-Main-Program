CREATE DATABASE People

USE People

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX)
	CHECK(DATALENGTH(Picture) <= 2097152),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)


INSERT INTO People([Name], Height, [Weight], Gender, Birthdate, Biography)
VALUES
		('Stefan Todorov', 1.8, 72, 'm', '06-24-1984', 'Biography of this person'),
		('Ivan Popov', 1.9, 75, 'm', '06-24-1984', 'Biography of this person'),
		('Svetla Trifonova', 1.73, 70, 'f', '06-24-1984', 'Biography of this person'),
		('Ivelina Peneva', 1.81, 68, 'f', '06-24-1984', 'Biography of this person'),
		('Miroslav Tonev', 1.75, 69, 'm', '06-24-1984', 'Biography of this person')

SELECT * FROM People
