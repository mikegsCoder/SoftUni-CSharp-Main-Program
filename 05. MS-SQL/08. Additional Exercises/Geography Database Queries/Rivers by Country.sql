SELECT
	c.CountryName,
	Continents.ContinentName,
	IIF(COUNT(cr.RiverId) IS NULL, 0, COUNT(cr.RiverId))  AS [RiversCount],
	IIF(SUM(r.Length) IS NULL, 0, SUM(r.Length)) AS [TotalLength]
FROM Countries AS c
	JOIN Continents ON Continents.ContinentCode = c.ContinentCode
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY Continents.ContinentName, c.CountryName
ORDER BY [RiversCount] DESC, [TotalLength] DESC, c.CountryName