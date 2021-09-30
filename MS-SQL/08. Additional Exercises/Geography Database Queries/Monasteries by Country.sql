CREATE TABLE Monasteries(
	Id INT PRIMARY KEY IDENTITY, 
	[Name] VARCHAR(250) NOT NULL, 
	CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode) NOT NULL
)

INSERT INTO Monasteries([Name], CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0

UPDATE Countries SET IsDeleted = 1
FROM Countries
WHERE (SELECT COUNT(*) FROM CountriesRivers WHERE CountriesRivers.CountryCode = Countries.CountryCode) > 3
	
SELECT m.[Name] AS Monastery, c.CountryName FROM Monasteries AS m
	JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY Monastery