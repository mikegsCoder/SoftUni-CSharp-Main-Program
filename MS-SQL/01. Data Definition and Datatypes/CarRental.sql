CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate INT CHECK(DAILYRATE >= 0 AND DAILYRATE <= 10) NOT NULL,
	WeeklyRate INT CHECK(WEEKLYRATE >= 0 AND WEEKLYRATE <= 10) NOT NULL,
	MonthlyRate INT CHECK(MONTHLYRATE >= 0 AND MONTHLYRATE <= 10) NOT NULL,
	WeekendRate INT CHECK(WEEKENDRATE >= 0 AND WEEKENDRATE <= 10) NOT NULL,
)


CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber INT NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear DATETIME NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(100),
	Available BIT NOT NULL,
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(20) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied BIT DEFAULT ('false'),
	TaxRate DECIMAL(4,2) NOT NULL,
	OrderStatus VARCHAR(13) CHECK (OrderStatus = 'Completed' OR OrderStatus = 'Not completed'),
	Notes NVARCHAR(MAX)
)


INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
	VALUES
			('Jeep', 5, 7, 4, 8),
			('Sedan', 5, 7, 4, 8),
			('City', 5, 7, 4, 8)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
	VALUES
			(24364323, 'Ford', 'Cougar', '05.09.2000', 1, 5, NULL, 'Used', 1),
			(24364323, 'Opel', 'Astra', '07.10.2015', 2, 5, NULL, 'Used', 0),
			(24364323, 'Nisan', 'Note', '12.01.2010', 3, 5, NULL, 'Used', 1)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
	VALUES
			('Ivan', 'Tonev', 'Worker', NULL),
			('Stefan', 'Petrov', 'Mechanic', NULL),
			('Ivan', 'Tonev', 'Boss', NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
	VALUES
			(1234435423, 'Dimitar Stoev', 'Somewhere in Sofia', 'Sofia', 2321, NULL),
			(1234435423, 'Atanas Bratoev', 'Somewhere in Varna', 'Varna', 9000, NULL),
			(1234435423, 'Hristo Botev', 'Somewhere in Burgas', 'Burgas', 43243, NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
	VALUES
			(1, 2, 3, 45, 123, 133, 10, '05.09.2020', '06.09.2020', 30, 1, 10.2, 'Completed', NULL),
			(2, 3, 1, 55, 153, 173, 20, '03.10.2020', '03.20.2020', 10, 0, 12.2, 'Not completed', NULL),
			(3, 1, 2, 65, 103, 173, 70, '05.09.2020', '06.09.2020', 30, 1, 15.4, 'Completed', NULL)

SELECT * FROM RentalOrders