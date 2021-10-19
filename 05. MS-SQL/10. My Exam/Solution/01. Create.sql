CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL, 
	CHECK ([Length] BETWEEN 10 AND 25),
	RingRange DECIMAL(3,2) NOT NULL, 
	CHECK (RingRange BETWEEN 1.5 AND 7.5)	
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL, 
	TasteStrength VARCHAR(15) NOT NULL, 
	ImageUrl NVARCHAR(100) NOT NULL	
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL, 
	BrandDescription VARCHAR(MAX)	
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL, 
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(15,2) NOT NULL,
	ImageUrl NVARCHAR(100) NOT NULL	
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL, 
	Country NVARCHAR(30) NOT NULL, 
	Streat NVARCHAR(100) NOT NULL, 
	ZIP VARCHAR(20) NOT NULL	
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Email NVARCHAR(50) NOT NULL, 
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(	
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL,
	PRIMARY KEY (ClientId, CigarId)
)