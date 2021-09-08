CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(40) NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(40) NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(40) NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(200) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating FLOAT CHECK(RATING >= 0 AND RATING <= 10) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Directors (DirectorName, Notes)
	VALUES
			('Stefsan Todorov', NULL),
			('Svetoslav Trifonov', 'Best Director'),
			('Elena Popova', NULL),
			('Stefka Asenova', NULL),
			('Ivan Enchev', NULL)


INSERT INTO Genres (GenreName, Notes)
	VALUES
			('SciFi', NULL),
			('Action', 'Too much action!'),
			('Fantasy', NULL),
			('Crime', NULL),
			('Mistery', 'Misterious')

INSERT INTO Categories (CategoryName, Notes)
	VALUES
			('Animated', NULL),
			('Action', 'Too much action!'),
			('Sports', NULL),
			('Gangster', NULL),
			('Mistery', NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
	VALUES
			('Title1', 2, '05.19.2020', 2, 1, 3, 6, NULL),
			('Title2', 1, '03.06.2020', 2, 5, 1, 7, NULL),
			('Title3', 5, '07.23.2021', 3, 2, 2, 5, NULL),
			('Title4', 4, '03.29.2020', 2, 3, 5, 10, NULL),
			('Title5', 3, '11.22.2021', 2, 4, 4, 8, NULL)