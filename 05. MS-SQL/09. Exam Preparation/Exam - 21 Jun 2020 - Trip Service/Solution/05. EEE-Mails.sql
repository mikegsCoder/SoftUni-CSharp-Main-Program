SELECT
	a.FirstName,
	a.LastName,
	FORMAT(a.Birthdate, 'MM-dd-yyyy') AS Birthdate,
	c.[Name] AS Hometown,
	a.Email
FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name