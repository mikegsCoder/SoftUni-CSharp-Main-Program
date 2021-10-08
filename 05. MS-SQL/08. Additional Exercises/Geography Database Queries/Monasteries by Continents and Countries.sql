UPDATE Countries SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode)
SELECT 'Hanga Abbey', CountryCode FROM Countries WHERE CountryName = 'Tanzania'

INSERT INTO Monasteries(Name, CountryCode)
SELECT 'Myin-Tin-Daik', CountryCode FROM Countries WHERE CountryName = 'Myanmar'

SELECT
	Continents.ContinentName,
	c.CountryName,
	COUNT(m.Id) AS MonasteriesCount
FROM Countries AS c
	JOIN Continents ON Continents.ContinentCode = c.ContinentCode
	LEFT JOIN Monasteries AS m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY Continents.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName