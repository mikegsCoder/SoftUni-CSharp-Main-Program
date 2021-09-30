SELECT 
	Currencies.CurrencyCode,
	Currencies.[Description] AS [Currency],
	COUNT(c.CountryCode) AS NumberOfCountries
FROM Countries AS c
	RIGHT JOIN Currencies ON Currencies.CurrencyCode = c.CurrencyCode
GROUP BY Currencies.[Description], Currencies.CurrencyCode
ORDER BY NumberOfCountries DESC, Currencies.[Description]