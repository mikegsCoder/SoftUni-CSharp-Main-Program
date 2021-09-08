CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber INT NOT NULL,
	EmergencyName VARCHAR(30) NOT NULL,
	EmergencyNumber INT NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(200)
)

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(200)
)

CREATE TABLE BedTypes(
	BedType NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(200)
)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(3,2),
	RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(200)
)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(10,2) NOT NULL,
	TaxRate DECIMAL(3,2),
	TaxAmount DECIMAL(10,2),
	PaymentTotal DECIMAL(10,2),
	Notes NVARCHAR(200)
)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(3, 2),
	PhoneCharge DECIMAL(15, 2),
	Notes NVARCHAR(200)
)

INSERT INTO Employees
		(FirstName, LastName, Title, Notes)
VALUES	    
	    ('Kiro', 'Kirov', 'employee1', NULL),
	    ('Ivan', 'Ivanov', 'employee2', NULL),
	    ('Pesho', 'Peshev', 'employee3', NULL)

INSERT INTO Customers
	    (FirstName, LastName, PhoneNumber,
	    EmergencyName, EmergencyNumber, Notes)
VALUES	    
	    ('Toshko', 'Toshkov', 123456, 'name1', 234324, NULL),
	    ('Stamat', 'Stamatov', 654321, 'name2', 6543534, NULL),
	    ('Gosho', 'Goshov', 223341, 'name3', 7657, NULL)
	    
INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES
		('Status1', NULL),
	    ('Status2', NULL),
	    ('Status3', NULL)

INSERT INTO RoomTypes(RoomType, Notes)
VALUES
		('Type1', NULL),
	    ('Type2', NULL),
	    ('Type3', NULL)

INSERT INTO BedTypes(BedType, Notes)
VALUES
		('Bed1', NULL),
	    ('Bed2', NULL),
	    ('Bed3', NULL)

INSERT INTO Rooms
	    (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES     
	    ('Type1', 'Bed1', 7.25, 'Status1', NULL),
	    ('Type2', 'Bed2', 8.30, 'Status2', NULL),
	    ('Type3', 'Bed3', 9.20, 'Status3', NULL)

INSERT INTO Payments
            (EmployeeId, PaymentDate, AccountNumber, 
            FirstDateOccupied, LastDateOccupied, 
            TotalDays, AmountCharged, TaxRate, 
            TaxAmount, PaymentTotal, Notes)
VALUES            
            (1, '2005-05-10', 1, '2005-05-05', '2005-05-10', 5, 305.50, 5.5, 35.72, 341.22, NULL),
            (2, '2007-07-15', 2, '2007-07-21', '2007-07-15', 6, 301.00, 6.5, 15.20, 316.20, NULL),
            (3, '2012-02-09', 3, '2012-02-16', '2012-02-09', 7, 450.25, 8.3, 25.20, 475.45, NULL)

INSERT INTO Occupancies
	    (EmployeeId, DateOccupied, AccountNumber,
	     RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES    
	    (1, '2019-09-15', 1, 1, 5.60, 15.90, NULL),
	    (3, '2015-07-16', 3, 3, 7.50, 16.20, NULL),
	    (2, '1999-05-16', 2, 2, 8.32, 12.35, NULL)